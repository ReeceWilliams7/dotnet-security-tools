[![.NET Main](https://github.com/ReeceWilliams7/dotnet-security-tools/actions/workflows/dotnet_main.yml/badge.svg)](https://github.com/ReeceWilliams7/dotnet-security-tools/actions/workflows/dotnet_main.yml)

# dotnet-security-tools

# A collection of convenient security related .NET tools.

## JSON Web Keys (JWKs)

Library and Tooling for creating Json Web Keys (JWKs)

## JsonWebKeyCreator.Core (Library/Package)

### Installation

```
dotnet add package RW7.DotNetSecurityTools.JsonWebKeyCreator.Core --version 1.0.0
```

### Usage

```csharp
// Create a new instance using the default ctor -
var jsonWebKeyCreator = new JsonWebKeyCreator();

// Create a new JWK -
var jsonWebKeyOutput = jsonWebKeyCreator.Create();
```

The `JsonWebKeyOutput` type looks like this -

```csharp
public class JsonWebKeyOutput
{
    // Internal .NET JsonWebKey type
    public JsonWebKey JsonWebKey { get; }

    // JSON serialized representation of the .NET JsonWebKey type
    public string JsonWebKeyString { get; }

    // Base64 encoded representation of the JSON serialized string
    public string Base64JsonWebKey { get; }

    // PEM Encoded RSA Public Key used to create the JWK
    public string RsaPublicKey { get; }

    // PEM Encoded RSA Private Key used to create the JWK
    public string RsaPrivateKey { get; }
}
```

## JsonWebKeyCreator (Tooling)

### Installation

```
dotnet tool install --global RW7.DotNetSecurityTools.JsonWebKeyCreator
```

Once installed, simply run the following command - 

```
create-jwk
```

By default, this will outputs the following to the console - 

* The full JsonWebKey itself (including private key parts)
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

```
-b | --output-base64
```

Whether to output the JWK Base64 encoded representation

```
-r | --output-rsa-keys
```

Whether to output the PEM encoded RSA Keys used to create the JWK

___

## Client Credentials

Library and Tooling for creating Client Credentials (ID and Secret), for use with, for example, OIDC or OAuth2.0 clients.

## ClientCredentialsCreator.Core (Library/Package)

### Installation

```
dotnet add package RW7.DotNetSecurityTools.ClientCredentialsCreator.Core
```

### Usage

```csharp
// Create a new instance using the default ctor -
var clientCredentialsCreator = new ClientCredentialsCreator();

// Create a new Client Credentials set -
var clientCredentials = clientCredentialsCreator.Create();
```

The `JsonWebKeyOutput` type looks like this -

```csharp
public class JsonWebKeyOutput
{
public class ClientCredentialsOutput
{
    // The Client Id
    public string ClientId { get; }
    
    // the Client Secret
    public string ClientSecret { get; }
}
```

## ClientCredentialsCreator (Tooling)

### Installation

```
dotnet tool install --global RW7.DotNetSecurityTools.ClientCredentialsCreator
```

### Usage

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
