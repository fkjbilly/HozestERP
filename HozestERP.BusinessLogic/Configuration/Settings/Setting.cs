

namespace HozestERP.BusinessLogic.Configuration.Settings
{
    /// <summary>
    /// Represents a setting
    /// </summary>
    public partial class Setting : BaseEntity
    {
        /// <summary>
        /// Gets or sets the setting identifier
        /// </summary>
        public int SettingID { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
    }
}
