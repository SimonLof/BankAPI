# BankAPI  💰

 Fake BankAPI using EntityFramework Core, Identity, Swagger and Automapper, and a mock database with about 100 000 customers. (database not included in repo)

## Endpoints  🔚

### `/api/Admin` 👮


#### `~/whoami` ❓

> Lists all the claims for currently signed in user. (For testing)


#### `~/getallusers`

> Get all accounts created with Identity. (Not the 100 000 customers, also for testing)


#### `~/createadmin`

> Create a new admin level login.
>
>  `{userName:string, password:string, gender:string, givenname:string, surname:string, streetaddress:string, city:string, zipcode:string, country:string, countrycode:string, email:email-string, phoneNumber:string }`


#### `~/newcustomer` 🧒

> Create a new customer. Creates an Identity-user for login, Customer for bank information, and a new Account associated with the customer.
>
>  `{userName:string, password:string, gender:string, givenname:string, surname:string, streetaddress:string, city:string, zipcode:string, country:string, countrycode:string, email:email-string, phoneNumber:string }`


#### `~/newloan` 💸

> Creates a new loan for the given account, and the associated transaction.
>
> `{ accountID:int, amount:double, duration:int }`
>
>  Duration is the time period (in months) over which the loan will be payed off.


#### `~/customer/{id}` 🔍

> Get an overview list of the given customers accounts.


### `/api/Customer`


#### `~/myaccounts` 🔍

> Get an overview list of all accounts for the signed in user.


#### `~/newaccount` 🤑

> Create a new account with the given parameters associated with the logged in customer.
>
>  `{ frequency:string, accountType:string }`
>
> Frequency is "monthly" or "weekly". Type is "s" for savings account and "t" for transaction account.


#### `~/account/{id}` 🔎

> Get detailed information about a specific account that the user owns. Lists all transactions for the given account.


 #### `~/depositOrWithdraw` ↪️

> Add or remove funds from a given account that the customer owns.
>
>  `{ accountId:int, amount:double }`


#### `~/transfer` ➡️

> Transfer funds from one of the signed in customers owned accounts to another account in the bank.
>
>  `{ fromAccountId:int, toAccountId:int, amount:double }`


### `/api/Login` ✔️

> Login with a username/password. Identity puts a cookie in the browser that auths the user until logging out or ending the session.
>
>  `{ userName:string, password:string }`


### `/api/logout` ❎

> Logs the user out. Removes the Identity-created cookie from the browser.
