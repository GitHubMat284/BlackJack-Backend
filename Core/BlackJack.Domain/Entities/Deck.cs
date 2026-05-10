namespace BlackJack.Domain.Entities;
public class Deck
{
    /// <summary>
    /// List of unique cards in a clasic deck
    /// </summary>
    private readonly List<Card> _cards = new();

    public Deck()
    {
        InitializeDeck();
    }

    private void InitializeDeck()
    {
        _cards.Clear();

        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank))) {
                _cards.Add(new Card(suit, rank));
            }
        }
    }

    /// <summary>
    /// Draws a random card from our deck
    /// </summary>
    /// <returns>A random unique card from the deck</returns>
    /// <exception cref="InvalidOperationException">When out of cards in the deck</exception>
    public Card Draw()
    {
        if (_cards.Count == 0) { 
            throw new InvalidOperationException("There are no cards left in the deck!");
        } 

        Random rand = new Random();
        int randomIndex = rand.Next(0, _cards.Count);

        var randomCard = _cards[randomIndex];
        _cards.RemoveAt(randomIndex);

        return randomCard;
    }
}
