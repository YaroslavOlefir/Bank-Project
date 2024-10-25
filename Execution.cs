using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project
{
	internal class Execution   // Eine Klasse, die je nach Kundenwunsch unterschiedliche Operationen ausführt
	{
		public void OperationExecution(int antwort, Client client)
		{
			switch (antwort)
			{
				case (1):
					client.ClientInfo();
					break;
				case (2):
					double depositAmount = client.AmountCheck();
					client.Deposit(depositAmount);
					break;
				case (3):
					double withdrawAmount = client.AmountCheck();
					client.Withdraw(withdrawAmount);
					break;
				case (4):
					client.CheckBalance();
					break;

			}
			Console.ReadKey();
			Console.Clear();
		}
	}
}
