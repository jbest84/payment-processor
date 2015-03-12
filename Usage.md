# Basic Usage #

In 1.1 the CTor for AuthorizeRequest was changed to:

```
AuthorizeRequest(string url, params IList [] args)
```


Here is a basic example:
```
            // Namespace
            using PaymentProcess;
```

```
            MerchantInfo mi = new MerchantInfo("LOGIN", "TRANSACTION_KEY");
            CreditTransactionInfo ti = new CreditTransactionInfo("3.1", amt, ccnum, exp_date, null, x_types.AUTH_CAPTURE, null);
            CustomerInfo ci = new CustomerInfo(firstName, lastName, company, address, city, state, zip, country, phone, fax,
                email, customerId, Request.UserHostAddress);
            ti.X_Method = "CC";
            ti.X_Test_Request = "TRUE";
            AuthorizeRequest request = new AuthorizeRequest(AuthorizeURL.TEST_URL, mi, ti, ci);
            AuthorizeResponse response = request.SendRequest();
```

_Please note that in 1.X, x\_types will become XTypes_

You can use the ReasonResponseCodes class to lookup more information for a given response code. This value is stored in response.ResponseCode. The developer will need to be familiar with these from the Authorize.NET specification. Your final code would look something like this after the SendRequest() call:
```
if (response.ResponseCode == "1")
{
    // Approved
}
```

# Additional Information #

The AuthorizeRequest constructor takes XXXInfo classes (Example: MerchantInfo). Each Info class is responsible for writing it's own POST string by overriding ToString.

# Tracing #

To enable tracing, add this to your application config file:

```
	<system.diagnostics>
		<switches>
                    <add name="PaymentProcess" value="4"/>
		</switches>
	</system.diagnostics>
```

This will enable you to view the raw POST url that is being sent to authorize.NET, as well the raw response before it is split by the delimited character. You will see each part of the POST string as it is being built.