using Domain.OrderAggregate;

public class SpecialOrder : Order
    {
        /// <summary>
        /// E.g. an additional discount amount for VIPs.
        /// </summary>
        public long Discount { get; set; }

        // Perhaps we store if user is VIP, has loyalty points, etc.
        public bool IsVip { get; set; } = true;

        // Override GetTotal() to apply discount logic
        public override long GetTotal()
        {
            var baseTotal = base.GetTotal();

            // Simple example: if VIP, subtract discount from total
            if (IsVip && Discount > 0)
            {
                return baseTotal - Discount;
            }

            return baseTotal;
        }
    }