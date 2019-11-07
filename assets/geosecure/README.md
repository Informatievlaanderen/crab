# Generate a Certificate

## General information

Run with OpenSSL 1.1.1d  10 Sep 2019

## Config file

[req]
default_bits       = 2048
default_md         = sha256
default_keyfile    = grar-geosecure.key
prompt             = no
encrypt_key        = no

distinguished_name = req_distinguished_name
attributes         = req_attributes
req_extensions     = v3_req

[req_distinguished_name]
countryName            = "BE"                                             # C=
stateOrProvinceName    = "Brussel"                                        # ST=
localityName           = "Brussel"                                        # L=
postalCode             = "1000"                                           # L/postalcode=
streetAddress          = "Havenlaan 88"                                   # L/street=
organizationName       = "BELVK0316380841"                                # O=
organizationalUnitName = "Informatie Vlaanderen"                          # OU=
commonName             = "kb.vlaanderen.be/aiv/grar-geosecure"            # CN=
emailAddress           = "informatie.vlaanderen@vlaanderen.be"            # CN/emailAddress=

[req_attributes]
unstructuredName = "Informatie Vlaanderen"

[v3_req]
basicConstraints = critical, CA:FALSE
keyUsage         = nonRepudiation, digitalSignature, keyEncipherment, dataEncipherment
extendedKeyUsage = critical, clientAuth

## Generate CSR + Private Key

rm grar-geosecure.{csr,key}
/usr/local/bin/openssl req -config grar-geosecure.conf -new -out grar-geosecure.csr
/usr/local/bin/openssl req -text -noout -verify -in grar-geosecure.csr
/usr/local/bin/openssl rsa -in grar-geosecure.key -check

## Convert a DER file (.crt .cer .der) to PEM

/usr/local/bin/openssl x509 -inform der -in grar-geosecure.der -out grar-geosecure.crt

## Inspect certificate

/usr/local/bin/openssl x509 -in grar-geosecure.crt -text -noout

# Convert a PEM certificate file and a private key to PKCS#12 (.pfx .p12)

/usr/local/bin/openssl pkcs12 -export -out grar-geosecure.pfx -inkey grar-geosecure.key -in grar-geosecure.crt
