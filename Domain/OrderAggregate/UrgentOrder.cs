 public class UrgentOrder : SpecialOrder
    {
        /// <summary>
        /// Additional fee or cost for urgent/expedited processing.
        /// </summary>
        public long UrgencyFee { get; set; } = 500; // example default

        // Override GetTotal() again to include the urgency fee
        public override long GetTotal()
        {
            // Start with the discount logic from SpecialOrder
            var specialOrderTotal = base.GetTotal();

            // Then add the UrgencyFee
            return specialOrderTotal + UrgencyFee;
        }
    }
