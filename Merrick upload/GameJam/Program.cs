using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

namespace GameJam
{
	internal class Program
	{
		
		public static string[] WeakAcids =
			{"Formic Acid (HCOOH)",
			"Acetic Acid (CH3COOH)",
			"Benzoic Acid (C6H5COOH)",
			"Hydrofluoric Acid (HF)",
			"Phosphoric Acid (H3PO4)",
			"Sulfurous Acid (H2SO3)",
			"Carbonic Acid (H2CO3)",
			"Nitrous Acid (HNO2)",
			"Hydrocyanic Acid (HCN)",
			"Hydrosulfuric Acid (H2S)",
			"Citric Acid (C6H8O7)"};    
		public static string[] WeakBases =
		{
			"Ammonium Hydroxide (NH4OH)",
			"Aniline (C6H5NH2)",
			"Ammonia (NH3)",
			"Methylamine (CH3NH2)",
			"Ethylamine (CH3CH2NH2)",
			"Aluminum hydroxide (Al(OH)3)",
			"Magnesium Hydroxide (Mg(OH)2)",
			"Pyridine (C5H5N)",
			"Sodium Bicarbonate (NaHCO3)"
		};
		const int MinPH = 2;
		const int MaxPH = 8;
		const double LPerCup = 0.236588;
		public static Random rnd = new();
		
		static void Main(string[] args)
		{
			

			Output(CustomerDesiredPH(),CustomerMoles());
			double[] conjBase = GetUserInput("Please enter the conjugate base in exponential notation using 'e'");
			double[] weakAcid = GetUserInput("Please enter the weak acid in exponential notation using 'e'");

			UsersAnswer(conjBase, weakAcid,CustomerMoles());

			Console.ReadLine();


		   
		}

		static double[] GetUserInput(string msg)
		{
			Console.WriteLine(msg);
			string input = Console.ReadLine();

			return SplitInput(input);

		}
		static double[] SplitInput(string input)
		{
			string[] inputs = input.Split('e');
			double[] notationInput = new double[inputs.Length];


			for (int i = 0; i < inputs.Length; i++)
			{
				notationInput[i] = Convert.ToDouble(inputs[i]);
			}


			return notationInput;
		}
		static void UsersAnswer(double[] conjBase, double[] weakAcid, double[] guyMoles)
		{
			double pKa;
			//User Inputs

			//Based on character
			pKa = 3.85;
			//guyMoles[0] = 5.0;
			//guyMoles[1] = -2;

			double ph = LPerCup * SNCalculator(conjBase[0], conjBase[1])
				- SNCalculator(guyMoles[0],guyMoles[1]); 
			ph /= (LPerCup * SNCalculator(weakAcid[0], weakAcid[1]) + SNCalculator(guyMoles[0], guyMoles[1]));
			ph = Math.Log(ph,10);
			ph += pKa;
			Console.WriteLine(ph);
		}

		static double SNCalculator(double bottom, double top)
		{
			double result = bottom * (Math.Pow(10, top));
			return result;
		}
		
		static double[] CustomerMoles()
		{
			double[] scienceNotation = new double[2];
			//Example: 0.01 x 10-1, 0.1x10-7 // 5x10-7
			scienceNotation[0] = rnd.Next(4, 7);
			scienceNotation[1] = (double)rnd.Next(-7, 0);
			return scienceNotation;
		}
		
		static bool CustomerDesiredPH()
		{
			bool solutionType;

			int type = rnd.Next(1, 3);
			if (type == 1)
			{
				solutionType = false; //is acid
			}
			else
			{
				solutionType = true; //is base
			}

			return solutionType;
		}

		static void Output(bool solutionType, double[] scienceNotation)
		{
			if (solutionType)
			{
				Console.WriteLine($"Hi I'm a Strong Acid of {Math.Round(scienceNotation[0], 3)}e{scienceNotation[1]} Moles. I want a buffer solution that'll get me to be within " +
					$"[3 to 5.5]");

				
			}
			else
			{
				Console.WriteLine($"Hi I'm a Strong Base of {Math.Round(scienceNotation[0], 3)}e{scienceNotation[1]} Moles. I want a buffer solution that'll get me to be within " +
					$"[8 to 10.5]");
			}
		}
	}
}
