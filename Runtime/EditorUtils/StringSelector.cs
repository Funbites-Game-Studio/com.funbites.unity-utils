#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;

namespace ScriptUtils.Editor
{
    public class StringSelector : OdinSelector<string>
    {
        private string[] options;

        public StringSelector(string[] options)
        {
            this.options = options;
        }

        protected override void BuildSelectionTree(OdinMenuTree tree)
        {
            tree.Selection.SupportsMultiSelect = false;
            tree.Config.DrawSearchToolbar = true;
            tree.Config.AutoFocusSearchBar = true;
            tree.Config.DrawScrollView = true;
            tree.AddRange(options, x => x);
            this.EnableSingleClickToSelect();
        }
    }  
}
#endif