﻿using System;

namespace ReposHelper
{
    public class Item : IComparable<Item>
    {

        #region Fields

        private EItemType type;
        private uint id;
        private string status;
        private string shortTitle;
        private byte priority;
        private DateTime creationDate;

        //This fields will be visible in "extended" item view
        private string description;
        private string? branchName;
        private string[]? mergedTo;

        #endregion

        #region Constructors

        public Item(EItemType type, uint id, string status, string shortTitle, byte priority, DateTime creationDate,
            string description, string? branchName, string[]? mergedTo)
        {
            this.type = type;
            this.id = id;
            this.status = status;
            this.shortTitle = shortTitle;
            this.priority = priority;
            this.creationDate = creationDate;
            this.description = description;
            this.branchName = branchName;
            this.mergedTo = mergedTo;
        }

        #endregion

        #region Operations

        public int CompareTo(Item? other)
        {
            if(other == null)
                return 1;

            if (this.type == other.type &&
                this.id == other.id &&
                this.status == other.status &&
                this.shortTitle == other.shortTitle &&
                this.priority == other.priority &&
                this.creationDate == other.creationDate &&
                this.description == other.description &&
                this.branchName == other.branchName)
            {
                if (this.mergedTo == null && other.mergedTo == null)
                    return 0;

                if ((this.mergedTo == null && other.mergedTo != null) || (this.mergedTo != null && other.mergedTo == null))
                    return 1;

                if(this.mergedTo.Length != other.mergedTo.Length)
                    return -1;

                if (this.mergedTo.Length == 0)
                    return 0;

                for (int i = 0; i < this.mergedTo.Length; i++)
                    if (this.mergedTo[i] != other.mergedTo[i])
                        return 1;

                return 0;
            }

            return 1;
        }

        #endregion

        #region Properties

        public EItemType Type { get { return type; } }
        public uint Id { get { return id; } }
        public string Status { get { return status; } }
        public string ShortTitle { get { return shortTitle; } }
        public byte Priority { get { return priority; } }
        public DateTime CreationDate { get { return creationDate; } }
        public string Description { get { return description; } }
        public string? BranchName { get { return branchName; } }
        public string[]? MergedTo { get { return mergedTo; } }

        #endregion

    }
}
