# Blockchain Console App

## Overview

This console application demonstrates the functionalities of a blockchain, showcasing three different samples: Numeric Blockchain, Blockchain Coin App, and Blockchain NFT App. 
These samples serve as examples of how a blockchain can be implemented for various use cases.

## Getting Started

1. **Clone the repository:**

``` bash
git clone https://github.com/X-dante-X/BlockchainConsoleApp.git
```
2. **Navigate to the project directory:**
``` bash
cd BlockchainConsoleApp\BlockchainConsoleApp
```
3. **Install dependencies using the package manager:**
``` bash
dotnet restore
```
4. **Run samples:**
``` bash
dotnet run
```

## Introduction

### Encoding
`f(x) = y, g(y) = x`
### Hash Function
- f(data) = code

- **Doesn't exist:** `g(code) = data` 

- **Collision:** `f(x1) = y, f(x2) = y, x1 != x2`

- **Probably:** `f(x1) = y, f(x2) = y, x1 = x2`

- **Guarantied:** `f(x1) = y, f(x2) = z, y != z, x1 != x2`

### Encryption
`f(data, key) = cryptotext`

**Doesn't exist or too expensive:**
    
`g(cryptotext) = data`

`g(cryptotext, data) = key` good encryption

### Asymmetric encryption
`f(data, publicKey) = cryptotext`

`g(cryptotext, privateKey) = data`
### Digital Sign
`f(data, privateKey) = cryptotext`

`g(cryptotext, publicKey) = data` => is was encrpyted by private key
### Verify Identity
Alice: Encrypt this, please - randomHash

Bob: f(randomHash, privateKey) = cryptotext

Alice: g(cryptotext, publicKey) = randomHash => It is **definitely** Bob

### Blockchain
block(parentHash, data)
```
block(null, data1)
block(hash(data1), data2)
block(hash(hash(data1) + data2), data3)
block(hash(hash(hash(data1) + data2) + data3, data4)
```
### Transactions
- Address is public key
- Address owner holds privateKey 

```
Transaction(
   From // Sender's publicKey
   To // Receiver's publicKey
   Ammount,
   Sign // Sign(From + To + Ammount, Senders privateKey)
 ) 
```
### Verify Transaction
1. From is the owner of asset at the current state of chain
2. Transaction is signed by From's privateKey
