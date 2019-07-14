namespace MasGlobal.HandsOn.DAL.DataMapper
{
    /// <summary>
    /// Manage Conections to avoid reopen several instances on app
    /// </summary>
    public static class DataMapperFactory
    {

        /// <summary>
        /// Dta mapper
        /// </summary>
        private static DataMapper DataContext
        {
            get;set;
        }

        /// <summary>
        /// If object is not instanced create new one otherwize return existent conection
        /// </summary>
        /// <returns></returns>
        public static DataMapper GetDataContext()
        {
            DataContext = DataContext ?? new DataMapper();
            return DataContext;
        }
    }
}
