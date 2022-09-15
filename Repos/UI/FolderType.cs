using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.UI
{
    public enum FolderType
    {
        [Description("Входящие")]
        Income,
        [Description("Черновики")]
        Drafts,
        [Description("Удаленные")]
        Deleted,
        [Description("Отправленные")]
        Sent,
        [Description("Спам")]
        Junk
    }
}
