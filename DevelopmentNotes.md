# Development Notes #
> All code is analyzed using Microsoft Source Analysis for C#. You can download it [here](http://code.msdn.microsoft.com/sourceanalysis)

> Only patches that pass the analysis will be accepted.

# Breaking Changes from 1.00 to 1.10 #
> Each info class now implements the IInfo interface. The AuthorizeRequest constructor is  no longer overloaded, and the number of info classes it takes is variable.

> _Old way pre 1.10:_
```
 MerchantInfo mi = new MerchantInfo("8wd65QSj", "8CP6zJ7uD875J6tY");
 BankTransactionInfo bi = new BankTransactionInfo("3.1", amt, abaNumber, accountNumber, acctType, bankName, acctName);
 CustomerInfo ci = new CustomerInfo(firstName, lastName, company, address, city, state, zip, country, phone, fax, email, customerId, Request.UserHostAddress);
 bi.X_Test_Request = "TRUE";
 AuthorizeRequest request = new AuthorizeRequest(mi, bi, AuthorizeURL.TEST_URL, null, null, null, ci, null);
```

> _New in 1.10:_
```
 MerchantInfo mi = new MerchantInfo("8wd65QSj", "8CP6zJ7uD875J6tY");
 BankTransactionInfo bi = new BankTransactionInfo("3.1", amt, abaNumber, accountNumber,  acctType, bankName, acctName);
 CustomerInfo ci = new CustomerInfo(firstName, lastName, company, address, city, state, zip, country, phone, fax, email, customerId, Request.UserHostAddress);
 bi.X_Test_Request = "TRUE";
 AuthorizeRequest request = new AuthorizeRequest(AuthorizeURL.TEST_URL, mi, bi, ci);
```

# Breaking Changes from 0.90 to trunk (1.0) #
> I did some refactoring that will break some things in 0.90. All properties were renamed using capital letters. For example: x\_type will become X\_Type. The Utils.cs got reworked, and the utility classes within it were extracted. The class x\_types became XTypes, the class x\_echeck\_types became XEcheckTypes, and the x\_bank\_account\_types became XBankAccountTypes.