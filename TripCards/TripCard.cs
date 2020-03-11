namespace TripCards
{
    /// <summary>
    /// The card of the single trip
    /// </summary>
    public class TripCard
    {
        /// <summary>
        /// Construct the card
        /// </summary>
        /// <param name="from"> Point of departure</param>
        /// <param name="to"> Destination </param>
        public TripCard(string from, string to)
        {
            this.From = from;
            this.To = to;
        }
        
        /// <summary>
        /// Gets point of departure
        /// </summary>
        public string From { get; }
        
        /// <summary>
        /// Gets destination
        /// </summary>
        public string To { get; }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            
            return string.Equals(this.From, ((TripCard)obj).From) && string.Equals(this.To, ((TripCard)obj).To);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((this.From != null ? this.From.GetHashCode() : 0) * 397) ^
                       (this.To != null ? this.To.GetHashCode() : 0);
            }
        }
    }
}