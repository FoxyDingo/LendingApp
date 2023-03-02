
namespace LendingApp.LendingDomain
{
    /// <summary>
    /// Objects shall contain an identifier
    /// </summary>
    public interface IIdentifiable
    {
        /// <summary>
        /// Identifier for the object
        /// </summary>
        public int Identifier { get; }
    }
}
