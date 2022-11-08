using System.ComponentModel.DataAnnotations;

namespace PerfectTip;

public partial class MainPage : ContentPage
{
	decimal bill;
	int tip;
	int noPerson = 1;


	public MainPage()
	{
		InitializeComponent();
	}

	private void txtBill_Completed(object sender, EventArgs e)
	{
		bill = decimal.Parse(txtBill.Text);
		CalculateTotal();

    }

	private void CalculateTotal()
	{
		//total tip
		var totalTip = (bill * tip) / 100;

		//tip by person
		var tipByPerson = (totalTip / noPerson);
		//lblTip.Text = tipByPerson.ToString();

		//****Concurrency format****
		lblTip.Text = $"{tipByPerson:C}";

		//subtotal
		var subTotal = (bill / noPerson);
        //lblSubtotal.Text = subTotal.ToString();
        lblSubtotal.Text = $"{subTotal:C}";

        //total
        var totalByPerson = (bill + totalTip) / noPerson;
        //lblTotal.Text = totalByPerson.ToString();
        lblTotal.Text = $"{totalByPerson:C}";

    }
	//what is a object sender??
	private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		tip = (int)sldTip.Value;
		lblTips.Text = $"Tip: {tip}%";
		CalculateTotal();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		if(sender is Button)
		{
			var btn = (Button)sender;
			var percentage = int.Parse(btn.Text.Replace("%",""));
			sldTip.Value = percentage;
		}
	}

	private void btnMinus_Clicked(object sender, EventArgs e)
	{
		if (noPerson > 1) { 
			noPerson--;
		}
		lblNoPersons.Text = noPerson.ToString();
		CalculateTotal();	
	}

	private void btnMax_Clicked(object sender, EventArgs e)
	{
		noPerson++;
		lblNoPersons.Text = noPerson.ToString();
		CalculateTotal();
	}
}

