namespace Funbites.UnityUtils.Editor
{
    public static class EditorFileUtils
    {
        public static void ShowExplorer(string itemPath)
        {
            itemPath = itemPath.Replace(@"/", @"\");
            System.Diagnostics.Process.Start("explorer.exe", "/select," + itemPath);
        }
    }
}
