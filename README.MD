# Cookies.txt Parser for .NET

## Introduction

A simple library for parsing cookies.txt files, Netscape HTTP Cookie File format used by tools like curl and wget, into:

- `System.Net.CookieCollection` for use by `HttpClient`
- `IReadOnlyList<Cookie>` for inspection (since it's difficult to enumerate a `CookieCollection`)

## Installation

The package is available at [NuGet](https://www.nuget.org/packages/CookiesTxtParser):

    dotnet add package CookiesTxtParser

## Usage

Parse a file by path:

    // To CookieCollection
    CookiesTxt.Parser.ParseFileAsCookieCollection("/path/to/cookies.txt");

    // To IReadOnlyList
    CookiesTxt.Parser.ParseFileAsCookies("/path/to/cookies.txt");

Parse a stream:

    // To CookieCollection
    CookiesTxt.Parser.ParseStreamAsCookieCollection(stream);

    // To IReadOnlyList
    CookiesTxt.Parser.ParseStreamAsCookies(stream);