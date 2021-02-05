using BlazorBJ.Client.Models.Enums;

namespace BlazorBJ.Client.Models
{
    public class Card
    {
        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }
        public bool IsVisible { get; set; }
        public string ImageName { get; set; }
        
        public int Score
        {
            get
            {
                return Value switch
                {
                    CardValue.King  => 10,
                    CardValue.Queen => 10,
                    CardValue.Jack => 10,
                    CardValue.Ace => 11,
                    _ => (int) Value
                };

            }
        }


        public bool IsTenCard => Score == 10;
        public bool IsAce => Value == CardValue.Ace;

        public override string ToString() =>
            $"{Suit} ${Value} ${(IsVisible ? "Visible" : "Not visible")} : {ImageName}";
    }
}