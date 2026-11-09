using GuessNumber.Core;
using GuessNumber.ConsoleApp;

var ui = new ConsoleUi();
var generator = new RandomNumberGenerator();
var game = new Game(generator, ui);

game.Play();