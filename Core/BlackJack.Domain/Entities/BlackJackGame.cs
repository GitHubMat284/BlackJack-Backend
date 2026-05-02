namespace BlackJack.Domain.Entities;
 
/// <summary>
/// Specifies the possible states of a blackjack game, including turn order, bust conditions, and game outcomes.
/// </summary>
/// <remarks>This enumeration helps determine the current status or result of a blackjack game. The values
/// indicate whether it is the player's or dealer's turn, if either has busted, or if the game has ended in a win, loss,
/// or push (tie).</remarks>
public enum GameStatus
{
    PlayerTurn,
    DealerTurn,
    PlayerBust,
    DealerBust,
    PlayerWin,
    DealerWin,
    Push
}
public class BlackJackGame
{
    /// <summary>
    /// Unique identifier for a single BlackJack game 
    /// </summary>
    public string ID { get; } = Guid.NewGuid().ToString();

    private readonly Deck _deck = new();
    public Player Player { get; } = new();
    public Dealer Dealer { get; } = new();
    public GameStatus Status { get; private set; }

    public BlackJackGame()
    {
        Start();
    }

    /// <summary>
    /// Initializes a new round by dealing starting cards to the player and dealer, and sets the initial game state.
    /// </summary>
    private void Start()
    {
        Player.Hand.Add(_deck.Draw());
        Dealer.Hand.Add(_deck.Draw());
        Player.Hand.Add(_deck.Draw());
        Dealer.Hand.Add(_deck.Draw());

        // Decide on early wins or allow Player's Turn
        DetermineStartingState();
    }

    private void DetermineStartingState()
    {
        int player = Player.Hand.GetHandValue();
        int dealer = Dealer.Hand.GetHandValue();

        bool playerBlackjack = player == 21;
        bool dealerBlackjack = dealer == 21;

        if (playerBlackjack && dealerBlackjack)
        {
            Status = GameStatus.Push;
        }
        else if (playerBlackjack)
        {
            Status = GameStatus.PlayerWin;
        }
        else if (dealerBlackjack)
        {
            Status = GameStatus.DealerWin;
        }
        else
        {
            Status = GameStatus.PlayerTurn;
        }
    }

    /// <summary>
    /// Processes the player's request to draw a card and updates the game status based on the result.
    /// </summary>
    /// <remarks>This method should be called during the player's turn; otherwise, an exception may be thrown. 
    /// After drawing a card, the game status is updated to reflect whether the player has busted or reached 21.</remarks>
    public void PlayerHit()
    {
        CheckPlayerTurn();

        Player.Hand.Add(_deck.Draw());

        if (Player.Hand.IsBust)
        {
            Status = GameStatus.PlayerBust;
        } else if (Player.Hand.IsTwentyOne)
        {
            Status = GameStatus.PlayerWin;
        }
    }

    /// <summary>
    /// Ends the player's turn and initiates the dealer's turn in the game.
    /// </summary>
    /// <remarks>Call this method when the player chooses to stand. After this method is called, the game
    /// transitions to the dealer's turn, and the winner is determined automatically. This method should only be called
    /// during the player's turn; otherwise, an exception may be thrown.</remarks>
    public void PlayerStand()
    {
        CheckPlayerTurn();

        Status = GameStatus.DealerTurn;
        PlayDealer();
        DetermineWinner();
    }

    private void PlayDealer()
    {
        while (Dealer.ShouldHit())
        {
            Dealer.Hand.Add(_deck.Draw());
        }
    }

    /// <summary>
    /// Determines the winner of the round or push (tie) after player stands
    /// </summary>
    private void DetermineWinner()
    {
        if (Dealer.Hand.IsBust)
        {
            Status = GameStatus.DealerBust;
            return;
        }

        int playerHandValue = Player.Hand.GetHandValue();
        int dealerHandValue = Dealer.Hand.GetHandValue();

        if (playerHandValue > dealerHandValue)
        {
            Status = GameStatus.PlayerWin;
        }
        else if (playerHandValue < dealerHandValue)
        {
            Status = GameStatus.DealerWin;
        }
        else
        {
            Status = GameStatus.Push;
        }
    }

    private void CheckPlayerTurn()
    {
        if (Status != GameStatus.PlayerTurn)
        {
            throw new InvalidOperationException("It is not the player's turn");
        }
    }
}