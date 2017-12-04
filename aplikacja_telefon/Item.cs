namespace aplikacja_telefon
{
    class Item
    {
        public Item()
        {
            this.Qty = "0";
            this.QtyToNewBox = "0";
            this.Changed = false;
        }

        public string Name { get; set; }
        public string Qty { get; set; }
        public string Id { get; set; }
        public string State { get; set; }
        public string QtyToNewBox { get; set; }
        public string IdQtyToNewBox { get; set; }
        public bool Changed { get; set; }
    }
}