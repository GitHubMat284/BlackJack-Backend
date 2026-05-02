namespace BlackJack.Domain.Entities;

/// <summary>
/// Entity class containing a hand of cards in a deck
/// </summary>
public class Hand
{
    /// <summary>
    /// Hand cards list
    /// </summary>
    private readonly List<Card> _cards = new();

    /// <summary>
    /// Public facing immutable cards collection
    /// </summary>
    public IReadOnlyList<Card> Cards => _cards;

    /// <summary>
    /// Adds the specified card to the collection.
    /// </summary>
    /// <param name="card">The card to add to the collection. Cannot be null or duplicate - not checked.</param>
    public void Add(Card card) => _cards.Add(card);

    /// <summary>
    /// Calculates the total value of the hand according to standard Blackjack rules.
    /// </summary>
    /// <remarks>If the hand contains one or more aces, each ace is counted as 11 unless this would
    /// cause the total to exceed 21, in which case aces are counted as 1 as needed. This method is typically used
    /// to determine the current score of a Blackjack hand.</remarks>
    /// <returns>The value of the hand, with aces counted as 1 or 11 to yield the highest possible value not exceeding 21</returns>
    public int GetHandValue() {
        int total = (_cards.Sum(card => card.GetValue()));

        int aceCount = (_cards.Sum(card => card.GetValue()));

        while (total > 21 && aceCount > 0)
        {
            aceCount--;
            total -= 10;
        }

        return total; 
    }

    /// <summary>
    /// Whether the most optimistic hand value is busted (AKA Over 21)
    /// </summary>
    public bool IsBust => GetHandValue() > 21;

    /// <summary>
    /// Whether the hand is 21
    /// </summary>
    public bool IsTwentyOne => GetHandValue() == 21;
}
