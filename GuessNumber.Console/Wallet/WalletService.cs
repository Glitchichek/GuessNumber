using GuessNumber.Core.Events;

namespace GuessNumber.Core.Wallet;

public class WalletService
{
    private readonly CoinWallet _wallet;

    public WalletService(CoinWallet wallet) => _wallet = wallet;

    public void OnGameEnded(object? sender, GameEndedEventArgs e)
    {
        if (e.Won)
        {
            _wallet.Add(1);
        }
    }
}