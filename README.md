[![.NET Main](https://github.com/ReeceWilliams7/dotnet-security-tools/actions/workflows/dotnet_main.yml/badge.svg)](https://github.com/ReeceWilliams7/dotnet-security-tools/actions/workflows/dotnet_main.yml)

# dotnet-security-tools

# A collection of convenient security related .NET tools.

## JsonWebKeyCreator

```
dotnet tool install --global RW7.DotNetSecurityTools.JsonWebKeyCreator
```

Produces a new JsonWebKey, internally using an RsaSecurityKey.

Once installed, simply run the following command - 

```
create-jwk
```

By default, this will outputs the following to the console - 

* The full JsonWebKey itself (including private key parts)
* Base64 encoded version of the full JsonWebKey
* PEM encoded RSA PRIVATE KEY (PKCS1)
* PEM encoded RSA PUBLIC KEY (PKCS1)

___

Additional command line are as follows - 

```
-t | --output-types
```

Where the JWK should be output to. Supported options are - 
* `Console`
* `File`

Multiple can be specified (values are case-insensitive), comma separated and in quotes.

For example - 

```
--output-type "console, file"
```

If not specified, then defaults to `Console`.

___

```
-d | --directory
```

If `File` is specified as an output type, this is the directory the files will be created in.

If not specified (and `File` is), then the value will default to [user temp folder]/[current ticks]. The resulting directory will be written in the log entries.

N.B. The directory structure will be created if it doesn't currently exist.

The following files will be written - 

* JsonWebKey.jwk - the contents of the JsonWebKey in indentended Json format.
* RsaPublicKey.pem - the PEM encoded RSA Public Key for the JsonWebKey.
* RsaPrivateKey.pem - the PEM encoded RSA Private Key used for the JsonWebKey.

___

## ClientCredentialsCreator

```
dotnet tool install --global RW7.DotNetSecurityTools.ClientCredentialsCreator
```

Produces a new Client ID and Secret, for use with, for example, OIDC or OAuth2.0 clients.

Once installed, simply run the following command - 

```
create-client-credentials
```

By default, this will outputs the following to the console - 

* The Client ID
* The Client Secret

___

Additional command line are as follows - 

```
-t | --output-types
```

Where the JWK should be output to. Supported options are - 
* `Console`
* `File`

Multiple can be specified (values are case-insensitive), comma separated and in quotes.

For example - 

```
--output-type "console, file"
```

If not specified, then defaults to `Console`.

___

```
-d | --directory
```

If `File` is specified as an output type, this is the directory the files will be created in.

If not specified (and `File` is), then the value will default to [user temp folder]/[current ticks]. The resulting directory will be written in the log entries.

N.B. The directory structure will be created if it doesn't currently exist.

The following files will be written - 

* ClientCredentials.txt - the Client ID and Client Secert, in clear text.
