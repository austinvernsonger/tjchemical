namespace SysCom.MMTDelegate
{
    /// <summary>
    /// Before or after posting an MMT passage, invoking this function.
    /// </summary>
    /// <param name="ID">The passage's ID.</param>
    public delegate void PostEvent(string ID);

    public delegate void RowsEvent(int RowsCount);
}