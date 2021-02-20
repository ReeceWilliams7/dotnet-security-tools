# dotnet-security-tools

# A collection of conventient security related .NET tools.

## JsonWebKeyCreator

```
dotnet tool install --global RW7.DotNetSecurityTools.JsonWebKeyCreator
```

Produces a new JsonWebKey, internally using an RsaSecurityKey.

Once installed, simply run the following command - 

```
create-jwk
```

This will outputs the following to the console - 

* The full JsonWebKey itself (including private key parts)
* Base64 encoded version of the full JsonWebKey
* PEM encoded RSA PRIVATE KEY (PKCS1)
* PEM encoded RSA PUBLIC KEY (PKCS1)

Additional command line and output options will be added in due course, e.g. to write the output to a file/files instead.
