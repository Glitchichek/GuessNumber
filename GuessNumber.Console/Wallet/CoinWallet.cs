namespace GuessNumber.Core.Wallet;

public class CoinWallet
{
    public int Coins { get; private set; }

    public CoinWallet(int initialCoins = 0) => Coins = initialCoins;

    public void Add(int amount = 1) => Coins += amount;

    public bool TrySpend(int amount = 1)
    {
        if (Coins < amount) return false;
        Coins -= amount;
        return true;
    }
}