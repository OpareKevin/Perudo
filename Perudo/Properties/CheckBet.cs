namespace Perudo.Properties
{
    public class CheckBet
    {
	    private readonly BoardMonitor _boardMonitor;

	    public CheckBet(BoardMonitor boardMonitor)
	    {
		    _boardMonitor = boardMonitor;
	    }

	    public Result CheckCall(Player player)
	    {
		    if(_boardMonitor. >= current_bet.dice_num) {
			    //The player was not lying! The caller gets penalized
			    if((turn+inner_turn)%2 == 0) {
				    //Penalize player
				    dice.awardOpponent();
			    }
			    else {
				    //Penalize opponent
				    dice.awardPlayer();
			    }
		    }
	    }
    }
}

/**
 
 protected void checkCall() {
		int[] all_dice = dice.getAllDice();
		int quantity = 0;
		for(int i = 0; i < 10; i ++) {
			if(all_dice[i] == current_bet.dice_face) {
				quantity++;
			}
		}
		if(quantity >= current_bet.dice_num) {
			//The player was not lying! The caller gets penalized
			if((turn+inner_turn)%2 == 0) {
				//Penalize player
				dice.awardOpponent();
			}
			else {
				//Penalize opponent
				dice.awardPlayer();
			}
		}
		else {
			//The player was lying. The bluffer gets penalized
			if((turn+inner_turn)%2 == 0) {
				//Penalize Opponent
				dice.awardPlayer();
			}
			else {
				//Penalize player
				dice.awardOpponent();
			}
		}
		if(dice.getPlayerDiceNum() == 10 || dice.getOpponentDiceNum() == 10) {
			done = true;
		}
		System.out.println("All dice: "+Arrays.toString(dice.getAllDice())+" "+turn+" "+inner_turn);
		dice.rollDice();
		turn += 1;
		inner_turn = -1;
	}

 */