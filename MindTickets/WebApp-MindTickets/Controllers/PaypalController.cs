using PayPal.Api;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApp_MindTickets.Models;

public class PayPalController : Controller
{
	private readonly PayPalAPIContextFactory _apiContextFactory;

	public PayPalController(PayPalAPIContextFactory apiContextFactory)
	{
		_apiContextFactory = apiContextFactory;
	}

	public IActionResult StartPayment()
	{
		var paymentModel = new PayPalPaymentModel
		{
			Currency = "USD",
			Amount = 0
		};

		var apiContext = _apiContextFactory.CreateAPIContext();


		var payment = Payment.Create(apiContext, new Payment
		{
			intent = "sale",
			payer = new Payer { payment_method = "paypal" },
			transactions = new List<Transaction>
			{
				new Transaction
				{
					amount = new Amount
					{
						currency = paymentModel.Currency,
						total = paymentModel.Amount.ToString()
					}
				}
			},
			redirect_urls = new RedirectUrls
			{
				return_url = Url.Action("PaymentSuccess", "PayPal", null, Request.Scheme),
				cancel_url = Url.Action("PaymentCancel", "PayPal", null, Request.Scheme)
			}
		});

		var approvalUrl = payment.links.FirstOrDefault(lnk => lnk.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase));
		if (approvalUrl != null)
		{
			return Redirect(approvalUrl.href);
		}

		return RedirectToAction("Index", "Home"); // Handle error
	}

}
