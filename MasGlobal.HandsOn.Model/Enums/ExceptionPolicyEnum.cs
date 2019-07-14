namespace MasGlobal.HandsOn.Model.Enums
{
    /// <summary>
    /// Exception Policy
    /// </summary>
    public enum ExceptionPolicyEnum
    {
        /// <summary>
        /// DAL Tier
        /// </summary>
        DataAccesLayer,
        
        /// <summary>
        /// BL Tier
        /// </summary>
        BusinessLayer,

        /// <summary>
        /// Web Api Tier
        /// </summary>
        ServiceLayer,

        /// <summary>
        /// Web Tier
        /// </summary>
        View
    }
}
