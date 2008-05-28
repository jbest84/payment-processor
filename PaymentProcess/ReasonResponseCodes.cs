//-----------------------------------------------------------------------
// <copyright file="ReasonResponseCodes.cs" company="Mission3, Inc.">
//      Copyright (c) Mission3, Inc. All rights reserved.
//
//      Permission is hereby granted, free of charge, to any person
//      obtaining a copy of this software and associated documentation
//      files (the "Software"), to deal in the Software without
//      restriction, including without limitation the rights to use,
//      copy, modify, merge, publish, distribute, sublicense, and/or sell
//      copies of the Software, and to permit persons to whom the
//      Software is furnished to do so, subject to the following
//      conditions:
//
//      The above copyright notice and this permission notice shall be
//      included in all copies or substantial portions of the Software.
//
//      THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//      EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//      OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//      NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//      HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
//      WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//      FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//      OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------

namespace PaymentProcess
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Reason response codes for authorize.NET responses
    /// </summary>
    public class ReasonResponseCodes
    {
        /// <summary>
        /// List of all the possible response reason
        /// </summary>
        private List<ResponseReason> reasons;

        /// <summary>
        /// ReasonResponseCodes CTor
        /// </summary>
        public ReasonResponseCodes()
        {
            List<ResponseReason> reasons = new List<ResponseReason>();
            reasons.Add(new ResponseReason(1, 1, "This transaction has been approved.", ""));
            reasons.Add(new ResponseReason(2, 2, "This transaction has been declined.", ""));
            reasons.Add(new ResponseReason(2, 3, "This transaction has been declined.", ""));
            reasons.Add(new ResponseReason(2, 4, "This transaction has been declined.", "The code returned from the processor indicating that the card used needs to be picked up."));
            reasons.Add(new ResponseReason(3, 5, "A valid amount is required.", "The value submitted in the amount field did not pass validation for a number."));
            reasons.Add(new ResponseReason(3, 6, "The credit card number is invalid.", ""));
            reasons.Add(new ResponseReason(3, 7, "The credit card expiration date is invalid.", "The format of the date submitted was incorrect."));
            reasons.Add(new ResponseReason(3, 8, "The credit card has expired.", ""));
            reasons.Add(new ResponseReason(3, 9, "The ABA code is invalid.", "The value submitted in the x_bank_aba_code field did not pass validation or was not for a valid financial institution."));
            reasons.Add(new ResponseReason(3, 10, "The account number is invalid.", "The value submitted in the x_bank_acct_num field did not pass validation."));
            reasons.Add(new ResponseReason(3, 11, "A duplicate transaction has been submitted.", "A transaction with identical amount and credit card information was submitted two minutes prior."));
            reasons.Add(new ResponseReason(3, 12, "An authorization code is required but not present.", "A transaction that required x_auth_code to be present was submitted without a value."));
            reasons.Add(new ResponseReason(3, 13, "The merchant API Login ID is invalid or the account is inactive.", ""));
            reasons.Add(new ResponseReason(3, 14, "The Referrer or Relay Response URL is invalid.", "The Relay Response or Referrer URL does not match the merchants configured value(s) or is absent. Applicable only to SIM and WebLink APIs."));
            reasons.Add(new ResponseReason(3, 15, "The transaction ID is invalid.", "The transaction ID value is non-numeric or was not present for a transaction that requires it (i.e., VOID, PRIOR_AUTH_CAPTURE, and CREDIT)."));
            reasons.Add(new ResponseReason(3, 16, "The transaction was not found.", "The transaction ID sent in was properly formatted but the gateway had no record of the transaction."));
            reasons.Add(new ResponseReason(3, 17, "The merchant does not accept this type of credit card.", "The merchant was not configured to accept the credit card submitted in the transaction."));
            reasons.Add(new ResponseReason(3, 18, "ACH transactions are not accepted by this merchant.", "The merchant does not accept electronic checks."));
            reasons.Add(new ResponseReason(3, 19, "An error occurred during processing. Please try again in 5 minutes.", ""));
            reasons.Add(new ResponseReason(3, 20, "An error occurred during processing. Please try again in 5 minutes.", ""));
            reasons.Add(new ResponseReason(3, 21, "An error occurred during processing. Please try again in 5 minutes.", ""));
            reasons.Add(new ResponseReason(3, 22, "An error occurred during processing. Please try again in 5 minutes.", ""));
            reasons.Add(new ResponseReason(3, 23, "An error occurred during processing. Please try again in 5 minutes.", ""));
            reasons.Add(new ResponseReason(3, 24, "The Nova Bank Number or Terminal ID is incorrect. Call Merchant Service Provider.", ""));

            reasons.Add(new ResponseReason(3, 25, "An error occurred during processing. Please try again in 5 minutes.", ""));
            reasons.Add(new ResponseReason(3, 26, "An error occurred during processing. Please try again in 5 minutes.", ""));
            reasons.Add(new ResponseReason(2, 27, "The transaction resulted in an AVS mismatch. The address provided does not match billing address of cardholder.", ""));
            reasons.Add(new ResponseReason(3, 28, "The merchant does not accept this type of credit card.", "The Merchant ID at the processor was not configured to accept this card type."));
            reasons.Add(new ResponseReason(3, 29, "The Paymentech identification numbers are incorrect. Call Merchant Service Provider.", ""));
            reasons.Add(new ResponseReason(3, 30, "The configuration with the processor is invalid. Call Merchant Service Provider.", ""));
            reasons.Add(new ResponseReason(3, 31, "The FDC Merchant ID or Terminal ID is incorrect. Call Merchant Service Provider.", "The merchant was incorrectly set up at the processor."));
            reasons.Add(new ResponseReason(3, 32, "This reason code is reserved or not applicable to this API.", ""));
            reasons.Add(new ResponseReason(3, 33, "FIELD cannot be left blank.", "The word FIELD will be replaced by an actual field name. This error indicates that a field the merchant specified as required was not filled in."));
            reasons.Add(new ResponseReason(3, 34, "The VITAL identification numbers are incorrect. Call Merchant Service Provider.", "The merchant was incorrectly set up at the processor."));
            reasons.Add(new ResponseReason(3, 35, "An error occurred during processing. Call Merchant Service Provider.", "The merchant was incorrectly set up at the processor."));
            reasons.Add(new ResponseReason(3, 36, "The authorization was approved, but settlement failed.", ""));
            reasons.Add(new ResponseReason(3, 37, "The credit card number is invalid.", ""));
            reasons.Add(new ResponseReason(3, 38, "The Global Payment System identification numbers are incorrect. Call Merchant Service Provider.", "The merchant was incorrectly set up at the processor."));
            reasons.Add(new ResponseReason(3, 39, "The supplied currency code is either invalid, not supported, not allowed for this merchant or doesn't have an exchange rate.", ""));
            reasons.Add(new ResponseReason(3, 40, "This transaction must be encrypted.", ""));
            reasons.Add(new ResponseReason(2, 41, "This transaction has been declined.", "Only merchants set up for the FraudScreen.Net service would receive this decline. This code will be returned if a given transactions fraud score is higher than the threshold set by the merchant."));
            reasons.Add(new ResponseReason(3, 42, "There is missing or invalid information in a required field.", "This is applicable only to merchants processing through the Wells Fargo SecureSource product who have requirements for transaction submission that are different from merchants not processing through Wells Fargo."));
            reasons.Add(new ResponseReason(3, 43, "The merchant was incorrectly set up at the processor. Call your Merchant Service Provider.", "The merchant was incorrectly set up at the processor."));
            reasons.Add(new ResponseReason(2, 44, "This transaction has been declined.", "The card code submitted with the transaction did not match the card code on file at the card issuing bank and the transaction was declined"));
            reasons.Add(new ResponseReason(2, 45, "This transaction has been declined.", "This error would be returned if the transaction received a code from the processor that matched the rejection criteria set by the merchant for both the AVS and Card Code filters."));
            reasons.Add(new ResponseReason(3, 46, "Your session has expired or does not exist. You must log in to continue working.", ""));
            reasons.Add(new ResponseReason(3, 47, "The amount requested for settlement may not be greater than the original amount authorized.", "This occurs if the merchant tries to capture funds greater than the amount of the original authorization-only transaction."));
            reasons.Add(new ResponseReason(3, 48, "This processor does not accept partial reversals.", "The merchant attempted to settle for less than the originally authorized amount."));
            reasons.Add(new ResponseReason(3, 49, "A transaction amount greater than $[amount] will not be accepted.", "The transaction amount submitted was greater than the maximum amount allowed."));
            reasons.Add(new ResponseReason(3, 50, "This transaction is awaiting settlement and cannot be refunded.", "Credits or refunds may only be performed against settled transactions. The transaction against which the credit/refund was submitted has not been settled, so a credit cannot be issued."));

            reasons.Add(new ResponseReason(3, 51, "The sum of all credits against this transaction is greater than the original transaction amount.", ""));
            reasons.Add(new ResponseReason(3, 52, "The transaction was authorized, but the client could not be notified; the transaction will not be settled.", ""));
            reasons.Add(new ResponseReason(3, 53, "The transaction type was invalid for ACH transactions.", "If x_method = ECHECK, x_type cannot be set to CAPTURE_ONLY."));
            reasons.Add(new ResponseReason(3, 54, "The referenced transaction does not meet the criteria for issuing a credit.", ""));
            reasons.Add(new ResponseReason(3, 55, "The sum of credits against the referenced transaction would exceed the original debit amount.", "The transaction is rejected if the sum of this credit and prior credits exceeds the original debit amount"));
            reasons.Add(new ResponseReason(3, 56, "This merchant accepts ACH transactions only; no credit card transactions are accepted.", "The merchant processes eCheck.Net transactions only and does not accept credit cards."));
            reasons.Add(new ResponseReason(3, 57, "An error occurred in processing. Please try again in 5 minutes.", ""));
            reasons.Add(new ResponseReason(3, 58, "An error occurred in processing. Please try again in 5 minutes.", ""));
            reasons.Add(new ResponseReason(3, 59, "An error occurred in processing. Please try again in 5 minutes.", ""));
            reasons.Add(new ResponseReason(3, 60, "An error occurred in processing. Please try again in 5 minutes.", ""));
            reasons.Add(new ResponseReason(3, 61, "An error occurred in processing. Please try again in 5 minutes.", ""));
            reasons.Add(new ResponseReason(3, 62, "An error occurred in processing. Please try again in 5 minutes.", ""));
            reasons.Add(new ResponseReason(3, 63, "An error occurred in processing. Please try again in 5 minutes.", ""));
            reasons.Add(new ResponseReason(3, 64, "The referenced transaction was not approved.", "This error is applicable to Wells Fargo SecureSource merchants only. Credits or refunds cannot be issued against transactions that were not authorized."));
            reasons.Add(new ResponseReason(2, 65, "This transaction has been declined.", "The transaction was declined because the merchant configured their account through the Merchant Interface to reject transactions with certain values for a Card Code mismatch."));
            reasons.Add(new ResponseReason(3, 66, "This transaction cannot be accepted for processing.", "The transaction did not meet gateway security guidelines."));
            reasons.Add(new ResponseReason(3, 67, "The given transaction type is not supported for this merchant.", "This error code is applicable to merchants using the Wells Fargo SecureSource product only. This product does not allow transactions of type CAPTURE_ONLY."));
            reasons.Add(new ResponseReason(3, 68, "The version parameter is invalid.", "The value submitted in x_version was invalid."));
            reasons.Add(new ResponseReason(3, 69, "The transaction type is invalid.", "The value submitted in x_type was invalid."));
            reasons.Add(new ResponseReason(3, 70, "The transaction method is invalid.", "The value submitted in x_method was invalid."));
            reasons.Add(new ResponseReason(3, 71, "The bank account type is invalid.", "The value submitted in x_bank_acct_type was invalid."));
            reasons.Add(new ResponseReason(3, 72, "The authorization code is invalid.", "The value submitted in x_auth_code was more than six characters in length."));
            reasons.Add(new ResponseReason(3, 73, "The drivers license date of birth is invalid.", "The format of the value submitted in x_drivers_license_dob was invalid."));
            reasons.Add(new ResponseReason(3, 74, "The duty amount is invalid.", "The value submitted in x_duty failed format validation."));
            reasons.Add(new ResponseReason(3, 75, "The freight amount is invalid.", "The value submitted in x_freight failed format validation."));

            reasons.Add(new ResponseReason(3, 76, "The tax amount is invalid.", "The value submitted in x_tax failed format validation."));
            reasons.Add(new ResponseReason(3, 77, "The SSN or tax ID is invalid.", "The value submitted in x_customer_tax_id failed validation."));
            reasons.Add(new ResponseReason(3, 78, "The Card Code (CVV2/CVC2/CID) is invalid.", "The value submitted in x_card_code failed format validation."));
            reasons.Add(new ResponseReason(3, 79, "The drivers license number is invalid.", "The value submitted in x_drivers_license_num failed format validation."));
            reasons.Add(new ResponseReason(3, 80, "The drivers license state is invalid.", "The value submitted in x_drivers_license_state failed format validation."));
            reasons.Add(new ResponseReason(3, 81, "The requested form type is invalid.", "The merchant requested an integration method not compatible with the AIM API."));
            reasons.Add(new ResponseReason(3, 82, "Scripts are only supported in version 2.5.", "The system no longer supports version 2.5; requests cannot be posted to scripts."));
            reasons.Add(new ResponseReason(3, 83, "The requested script is either invalid or no longer supported.", "The system no longer supports version 2.5; requests cannot be posted to scripts."));
            reasons.Add(new ResponseReason(3, 84, "This reason code is reserved or not applicable to this API.", ""));
            reasons.Add(new ResponseReason(3, 85, "This reason code is reserved or not applicable to this API.", ""));
            reasons.Add(new ResponseReason(3, 86, "This reason code is reserved or not applicable to this API.", ""));
            reasons.Add(new ResponseReason(3, 87, "This reason code is reserved or not applicable to this API.", ""));
            reasons.Add(new ResponseReason(3, 88, "This reason code is reserved or not applicable to this API.", ""));
            reasons.Add(new ResponseReason(3, 89, "This reason code is reserved or not applicable to this API.", ""));
            reasons.Add(new ResponseReason(3, 90, "This reason code is reserved or not applicable to this API.", ""));
            reasons.Add(new ResponseReason(3, 91, "Version 2.5 is no longer supported.", ""));
            reasons.Add(new ResponseReason(3, 92, "The gateway no longer supports the requested method of integration.", ""));
            reasons.Add(new ResponseReason(3, 93, "A valid country is required.", "This code is applicable to Wells Fargo SecureSource merchants only. Country is a required field and must contain the value of a supported country."));
            reasons.Add(new ResponseReason(3, 94, "The shipping state or country is invalid.", "This code is applicable to Wells Fargo SecureSource merchants only."));
            reasons.Add(new ResponseReason(3, 95, "A valid state is required.", "This code is applicable to Wells Fargo SecureSource merchants only."));
            reasons.Add(new ResponseReason(3, 96, "This country is not authorized for buyers.", "This code is applicable to Wells Fargo SecureSource merchants only. Country is a required field and must contain the value of a supported country."));
            reasons.Add(new ResponseReason(3, 97, "This transaction cannot be accepted.", "Applicable only to SIM API. Fingerprints are only valid for a short period of time. This code indicates that the transaction fingerprint has expired."));
            reasons.Add(new ResponseReason(3, 98, "This transaction cannot be accepted.", "Applicable only to SIM API. The transaction fingerprint has already been used."));
            reasons.Add(new ResponseReason(3, 99, "This transaction cannot be accepted.", "Applicable only to SIM API. The server-generated fingerprint does not match the merchant-specified fingerprint in the x_fp_hash field."));
            reasons.Add(new ResponseReason(3, 100, "The eCheck.Net type is invalid.", "Applicable only to eCheck.Net. The value specified in the x_echeck_type field is invalid."));

            reasons.Add(new ResponseReason(3, 101, "The given name on the account and/or the account type does not match the actual account.", "Applicable only to eCheck.Net. The specified name on the account and/or the account type do not match the NOC record for this account."));
            reasons.Add(new ResponseReason(3, 102, "This request cannot be accepted.", "A password or Transaction Key was submitted with this WebLink request. This is a high security risk."));
            reasons.Add(new ResponseReason(3, 103, "This transaction cannot be accepted.", "A valid fingerprint, Transaction Key, or password is required for this transaction."));
            reasons.Add(new ResponseReason(3, 104, "This transaction is currently under review.", "Applicable only to eCheck.Net. The value submitted for country failed validation."));
            reasons.Add(new ResponseReason(3, 105, "This transaction is currently under review.", "Applicable only to eCheck.Net. The values submitted for city and country failed validation."));
            reasons.Add(new ResponseReason(3, 106, "This transaction is currently under review.", "Applicable only to eCheck.Net. The value submitted for company failed validation."));
            reasons.Add(new ResponseReason(3, 107, "This transaction is currently under review.", "Applicable only to eCheck.Net. The value submitted for bank account name failed validation."));
            reasons.Add(new ResponseReason(3, 108, "This transaction is currently under review.", "Applicable only to eCheck.Net. The values submitted for first name and last name failed validation."));
            reasons.Add(new ResponseReason(3, 109, "This transaction is currently under review.", "Applicable only to eCheck.Net. The values submitted for first name and last name failed validation."));
            reasons.Add(new ResponseReason(3, 110, "This transaction is currently under review.", "Applicable only to eCheck.Net. The value submitted for bank account name does not contain valid characters."));
            reasons.Add(new ResponseReason(3, 111, "A valid billing country is required.", "This code is applicable to Wells Fargo SecureSource merchants only."));
            reasons.Add(new ResponseReason(3, 112, "A valid billing state/province is required.", "This code is applicable to Wells Fargo SecureSource merchants only."));
            reasons.Add(new ResponseReason(3, 116, "The authentication indicator is invalid.", "This error is only applicable to Verified by Visa and MasterCard SecureCode transactions. The ECI value for a Visa transaction; or the UCAF indicator for a MasterCard transaction submitted in the x_authentication_indicator field is invalid."));
            reasons.Add(new ResponseReason(3, 117, "The cardholder authentication value is invalid.", "This error is only applicable to Verified by Visa and MasterCard SecureCode transactions. The CAVV for a Visa transaction; or the AVV/UCAF for a MasterCard transaction is invalid."));
            reasons.Add(new ResponseReason(3, 118, "The combination of authentication indicator and cardholder authentication value is invalid.", "This error is only applicable to Verified by Visa and MasterCard SecureCode transactions. The combination of authentication indicator and cardholder authentication value for a Visa or MasterCard transaction is invalid."));
            reasons.Add(new ResponseReason(3, 119, "Transactions having cardholder authentication values cannot be marked as recurring.", "This error is only applicable to Verified by Visa and MasterCard SecureCode transactions. Transactions submitted with a value in x_authentication_indicator and x_recurring_billing=YES will be rejected."));
            reasons.Add(new ResponseReason(3, 120, "An error occurred during processing. Please try again.", "The system-generated void for the original timed-out transaction failed. (The original transaction timed out while waiting for a response from the authorizer.)"));
            reasons.Add(new ResponseReason(3, 121, "An error occurred during processing. Please try again.", "The system-generated void for the original errored transaction failed. (The original transaction experienced a database error.)"));
            reasons.Add(new ResponseReason(3, 122, "An error occurred during processing. Please try again.", "The system-generated void for the original errored transaction failed. (The original transaction experienced a processing error.)"));
            reasons.Add(new ResponseReason(3, 123, "This account has not been given the permission(s) required for this request.", "The transaction request must include the API Login ID associated with the payment gateway account."));

            reasons.Add(new ResponseReason(2, 127, "The transaction resulted in an AVS mismatch. The address provided does not match billing address of cardholder.", "The system-generated void for the original AVS-rejected transaction failed."));
            reasons.Add(new ResponseReason(3, 128, "This transaction cannot be processed.", "The customers financial institution does not currently allow transactions for this account."));
            reasons.Add(new ResponseReason(3, 130, "This payment gateway account has been closed.", "IFT: The payment gateway account status is Blacklisted."));
            reasons.Add(new ResponseReason(3, 131, "This transaction cannot be accepted at this time.", "IFT: The payment gateway account status is Suspended-STA."));
            reasons.Add(new ResponseReason(3, 132, "This transaction cannot be accepted at this time.", "IFT: The payment gateway account status is Suspended-Blacklist."));
            reasons.Add(new ResponseReason(2, 141, "This transaction has been declined.", "The system-generated void for the original FraudScreen-rejected transaction failed."));
            reasons.Add(new ResponseReason(2, 145, "This transaction has been declined.", "The system-generated void for the original card code-rejected and AVS-rejected transaction failed."));
            reasons.Add(new ResponseReason(3, 152, "The transaction was authorized, but the client could not be notified; the transaction will not be settled.", "The system-generated void for the original transaction failed. The response for the original transaction could not be communicated to the client."));
            reasons.Add(new ResponseReason(2, 165, "This transaction has been declined.", "The system-generated void for the original card code-rejected transaction failed."));
            reasons.Add(new ResponseReason(3, 170, "An error occurred during processing. Please contact the merchant.", "Concord EFS Provisioning at the processor has not been completed."));
            reasons.Add(new ResponseReason(3, 171, "An error occurred during processing. Please contact the merchant.", "Concord EFS This request is invalid."));
            reasons.Add(new ResponseReason(3, 172, "An error occurred during processing. Please contact the merchant.", "Concord EFS The store ID is invalid."));
            reasons.Add(new ResponseReason(3, 173, "An error occurred during processing. Please contact the merchant.", "Concord EFS The store key is invalid."));
            reasons.Add(new ResponseReason(3, 174, "The transaction type is invalid. Please contact the merchant.", "Concord EFS This transaction type is not accepted by the processor."));
            reasons.Add(new ResponseReason(3, 175, "The processor does not allow voiding of credits.", "Concord EFS This transaction is not allowed. The Concord EFS processing platform does not support voiding credit transactions. Please debit the credit card instead of voiding the credit."));

            reasons.Add(new ResponseReason(3, 180, "An error occurred during processing. Please try again.", "The processor response format is invalid."));
            reasons.Add(new ResponseReason(3, 181, "An error occurred during processing. Please try again.", "The system-generated void for the original invalid transaction failed. (The original transaction included an invalid processor response format.)"));
            reasons.Add(new ResponseReason(3, 185, "This reason code is reserved or not applicable to this API.", ""));
            reasons.Add(new ResponseReason(4, 193, "The transaction is currently under review.", "The transaction was placed under review by the risk management system."));
            reasons.Add(new ResponseReason(2, 200, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The credit card number is invalid."));
            reasons.Add(new ResponseReason(2, 201, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The expiration date is invalid."));
            reasons.Add(new ResponseReason(2, 202, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The transaction type is invalid."));
            reasons.Add(new ResponseReason(2, 203, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The value submitted in the amount field is invalid."));
            reasons.Add(new ResponseReason(2, 204, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The department code is invalid."));
            reasons.Add(new ResponseReason(2, 205, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The value submitted in the merchant number field is invalid."));
            reasons.Add(new ResponseReason(2, 206, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The merchant is not on file."));
            reasons.Add(new ResponseReason(2, 207, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The merchant account is closed."));
            reasons.Add(new ResponseReason(2, 208, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The merchant is not on file."));
            reasons.Add(new ResponseReason(2, 209, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. Communication with the processor could not be established."));
            reasons.Add(new ResponseReason(2, 210, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The merchant type is incorrect."));

            reasons.Add(new ResponseReason(2, 211, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The cardholder is not on file."));
            reasons.Add(new ResponseReason(2, 212, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The bank configuration is not on file"));
            reasons.Add(new ResponseReason(2, 213, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The merchant assessment code is incorrect."));
            reasons.Add(new ResponseReason(2, 214, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. This function is currently unavailable."));
            reasons.Add(new ResponseReason(2, 215, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The encrypted PIN field format is invalid."));
            reasons.Add(new ResponseReason(2, 216, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The ATM term ID is invalid."));
            reasons.Add(new ResponseReason(2, 217, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. This transaction experienced a general message format problem."));
            reasons.Add(new ResponseReason(2, 218, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The PIN block format or PIN availability value is invalid."));
            reasons.Add(new ResponseReason(2, 219, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The ETC void is unmatched."));
            reasons.Add(new ResponseReason(2, 220, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The primary CPU is not available."));
            reasons.Add(new ResponseReason(2, 221, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. The SE number is invalid."));
            reasons.Add(new ResponseReason(2, 222, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. Duplicate auth request (from INAS)."));
            reasons.Add(new ResponseReason(2, 223, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. This transaction experienced an unspecified error."));
            reasons.Add(new ResponseReason(2, 224, "This transaction has been declined.", "This error code applies only to merchants on FDC Omaha. Please re-enter the transaction."));

            reasons.Add(new ResponseReason(3, 243, "Recurring billing is not allowed for this eCheck.Net type.", "The combination of values submitted for x_recurring_billing and x_echeck_type is not allowed."));
            reasons.Add(new ResponseReason(3, 244, "This eCheck.Net type is not allowed for this Bank Account Type.", "The combination of values submitted for x_bank_acct_type and x_echeck_type is not allowed."));
            reasons.Add(new ResponseReason(3, 245, "This eCheck.Net type is not allowed when using the payment gateway hosted payment form.", "The value submitted for x_echeck_type is not allowed when using the payment gateway hosted payment form."));
            reasons.Add(new ResponseReason(3, 246, "This eCheck.Net type is not allowed.", "The merchants payment gateway account is not enabled to submit the eCheck.Net type."));
            reasons.Add(new ResponseReason(3, 247, "This eCheck.Net type is not allowed.", "The combination of values submitted for x_type and x_echeck_type is not allowed."));
            reasons.Add(new ResponseReason(3, 248, "The check number is invalid.", "Invalid check number. Check number can only consist of letters and numbers and not more than 15 characters."));
            reasons.Add(new ResponseReason(2, 250, "This transaction has been declined.", "This transaction was submitted from a blocked IP address."));
            reasons.Add(new ResponseReason(2, 251, "This transaction has been declined.", "The transaction was declined as a result of triggering a Fraud Detection Suite filter."));
            reasons.Add(new ResponseReason(4, 252, "Your order has been received. Thank you for your business!", "The transaction was accepted, but is being held for merchant review. The merchant may customize the customer response in the Merchant Interface."));
            reasons.Add(new ResponseReason(4, 253, "Your order has been received. Thank you for your business!", "The transaction was accepted and was authorized, but is being held for merchant review. The merchant may customize the customer response in the Merchant Interface."));
            reasons.Add(new ResponseReason(2, 254, "Your transaction has been declined.", "The transaction was declined after manual review."));
            reasons.Add(new ResponseReason(3, 261, "An error occurred during processing. Please try again.", "The transaction experienced an error during sensitive data encryption and was not processed. Please try again."));
            reasons.Add(new ResponseReason(3, 270, "The line item [item number] is invalid.", "A value submitted in x_line_item for the item referenced is invalid."));
            reasons.Add(new ResponseReason(3, 271, "The number of line items submitted is not allowed. A maximum of 30 line items can be submitted.", "The number of line items submitted exceeds the allowed maximum of 30."));
            this.reasons = reasons;
        }

        /// <summary>
        /// Gets the notes for a given reason code
        /// </summary>
        /// <param name="reasonCode">Response reason code to lookup</param>
        /// <returns>Notes string for the given reason code</returns>
        public string GetReasonNote(int reasonCode)
        {
            ResponseReason reason = this.FindMatch(reasonCode);
            return reason.IsEmpty ? null : reason.notes;
        }

        /// <summary>
        /// Gets the reason text for a given reason code
        /// </summary>
        /// <param name="reasonCode">Response reason code to lookup</param>
        /// <returns>Reason text for the given reason code</returns>
        public string GetReasonText(int reasonCode)
        {
            ResponseReason reason = this.FindMatch(reasonCode);
            return reason.IsEmpty ? null : reason.responseReasonText;
        }

        /// <summary>
        /// Finds the response reason for a given code
        /// </summary>
        /// <param name="reasonCode">Response reason code to lookup</param>
        /// <returns>ResponseReason in the list of reasons</returns>
        private ResponseReason FindMatch(int reasonCode)
        {
            foreach (ResponseReason reason in this.reasons)
            {
                if (reason.responseReasonCode == reasonCode)
                {
                    return reason;
                }
            }

            return new ResponseReason(true);
        }
    }
}