using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScenarioViewer.Model.Readers;

namespace ScenarioViewer.Model.Files
{
    public class CriteriaTree : IDBObjectReader
    {
        public const string FileName = @"CriteriaTree.db2";

        public uint Id { get; set; }
        public uint CriteriaId { get; set; }
        public Criteria Criteria { get; set; }
        public uint Amount { get; set; }
        public string Description { get; set; }
        public ushort ParentId { get; set; }
        public CriteriaTree Parent { get; set; }
        public List<CriteriaTree> Children { get; set; }
        public CriteriaTreeFlags Flags { get; set; }
        public CriteriaTreeOperator Operator { get; set; }
        public short OrderIndex { get; set; }

        public CriteriaTree()
        {
            Children = new List<CriteriaTree>();
        }

        public IEnumerable<TreeNode> GetChildrenTreeNodes(bool verbose)
        {
            if (verbose)
                return GetVerboseChildrenTreeNodes();

            if (Parent == null && Operator == CriteriaTreeOperator.All)
                return Children.SelectMany(child => child.GetChildrenTreeNodes(verbose));
            
            if (Criteria != null)
            {
                if (Amount > 1 && !(Parent != null && Parent.Operator == CriteriaTreeOperator.SumChildren))
                {
                    TreeNode node = new TreeNode(Criteria.ToString(verbose, this));
                    node.Tag = Criteria;

                    TreeNode nodeParent = new TreeNode(ToString(verbose), new [] {node});
                    nodeParent.Tag = this;
                    return new List<TreeNode> {nodeParent};
                }
                else
                {
                    TreeNode node = new TreeNode(Criteria.ToString(verbose, this));
                    node.Tag = Criteria;
                    return new List<TreeNode> {node};
                }
            }

            if ((Operator == CriteriaTreeOperator.All || Operator == CriteriaTreeOperator.Any) && Children.Count == 1 &&
                Children[0].Criteria != null)
            {
                TreeNode node = new TreeNode(Children[0].Criteria.ToString(verbose, Children[0]));
                node.Tag = Children[0].Criteria;
                return new List<TreeNode> {node};
            }

            TreeNode parent = new TreeNode(ToString(verbose));
            parent.Tag = this;
            foreach (var child in Children)
            {
                if (Operator == CriteriaTreeOperator.SumChildrenWeight && child.Operator == CriteriaTreeOperator.Single &&
                    child.Criteria != null)
                {
                    TreeNode node = new TreeNode(child.Criteria.ToString(verbose, child));
                    node.Tag = child.Criteria;
                    parent.Nodes.Add(node);
                }
                else
                    parent.Nodes.AddRange(child.GetChildrenTreeNodes(verbose).ToArray());
            }

            return new List<TreeNode> {parent};
        }

        private IEnumerable<TreeNode> GetVerboseChildrenTreeNodes()
        {
            if (Criteria != null)
            {
                if (Amount > 1 && !(Parent != null && Parent.Operator == CriteriaTreeOperator.SumChildren))
                {
                    TreeNode node = new TreeNode(Criteria.ToString(true, this));
                    node.Tag = Criteria;

                    TreeNode nodeParent = new TreeNode(ToString(true), new[] { node });
                    nodeParent.Tag = this;
                    return new List<TreeNode> { nodeParent };
                }
                else
                {
                    TreeNode node = new TreeNode(Criteria.ToString(true, this));
                    node.Tag = Criteria;
                    return new List<TreeNode> { node };
                }
            }

            TreeNode parent = new TreeNode(ToString(true));
            parent.Tag = this;
            parent.Nodes.AddRange(Children.SelectMany(child => child.GetVerboseChildrenTreeNodes()).ToArray());
            return new List<TreeNode> {parent};
        }
        
        public string ToString(bool verbose)
        {
            string description = "";
            switch (Operator)
            {
                case CriteriaTreeOperator.Single:
                    if (Parent.Operator == CriteriaTreeOperator.SumChildrenWeight)
                        description = $"Increase parent criteria tree progress by {Amount}";
                    else
                        description = $"The following criteria is met" + (Amount > 1 ? $" {Amount} times" : "");
                    break;
                case CriteriaTreeOperator.SingleNotCompleted:
                    description = $"The following criteria is not met";
                    break;
                case CriteriaTreeOperator.All:
                    description = $"All of the following criterias are met";
                    break;
                case CriteriaTreeOperator.SumChildren:
                    description = $"The following criterias are met {Amount} time" + (Amount > 1 ? "s" : "");
                    break;
                case CriteriaTreeOperator.MaxChild:
                    description = $"Any of the following criterias are met {Amount} time" + (Amount > 1 ? "s" : "");
                    break;
                case CriteriaTreeOperator.CountDirectChildren:
                    description = $"At least {Amount} of the following criterias are met at least once";
                    break;
                case CriteriaTreeOperator.Any:
                    description = $"At least {Amount} criteria" + (Amount > 1 ? "s are" : " is") + " met";
                    break;
                case CriteriaTreeOperator.SumChildrenWeight:
                    description = $"Progress is more than {Amount}";
                    break;
            }

            if (verbose)
                description = $"CT {Id} - {description}";

            return description;
        }
        
        public void ReadObject(IWowClientDBReader dbReader, BinaryReader reader, IDBCDataProvider dbcDataProvider, IDBDataProvider dbDataProvider)
        {
            using (BinaryReader br = reader)
            {
                if (dbReader.HasSeparateIndexColumn)
                    Id = reader.ReadUInt32();

                CriteriaId = reader.ReadUInt32();
                Amount = reader.ReadUInt32();

                if (dbReader.HasInlineStrings)
                    Description = br.ReadStringNull();
                else if (dbReader is STLReader)
                {
                    int offset = br.ReadInt32();
                    Description = (dbReader as STLReader).ReadString(offset);
                }
                else
                {
                    Description = dbReader.StringTable[br.ReadInt32()];
                }

                ParentId = reader.ReadUInt16();
                Flags = (CriteriaTreeFlags) reader.ReadUInt16();
                Operator = (CriteriaTreeOperator) reader.ReadByte();
                OrderIndex = reader.ReadInt16();
            }
        }
    }

    [Flags]
    public enum CriteriaTreeFlags : ushort
    {
        [Description("Progress bar")]
        ProgressBar         = 0x0001,
        [Description("Progress is date")]
        ProgressIsDate      = 0x0004,
        [Description("Show currency icon")]
        ShowCurrencyIcon    = 0x0008,
        [Description("Alliance only")]
        AllianceOnly        = 0x0200,
        [Description("Horde only")]
        HordeOnly           = 0x0400,
        [Description("Show required count")]
        ShowRequiredCount   = 0x0800
    };

    public enum CriteriaTreeOperator : byte
    {
        [Description("Single")]
        Single              = 0,
        [Description("SingleNotCompleted")]
        SingleNotCompleted  = 1,
        [Description("All")]
        All                 = 4,
        [Description("Sum children")]
        SumChildren         = 5,
        [Description("Max child")]
        MaxChild            = 6,
        [Description("Count direct children")]
        CountDirectChildren = 7,
        [Description("Any")]
        Any                 = 8,
        [Description("Sum children weight")]
        SumChildrenWeight   = 9
    };
}
