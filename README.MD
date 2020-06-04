# Cookies.txt Parser for .NET

## Introduction

A simple library for parsing cookies.txt files used by tools like curl and wget into `System.Net.CookieCollection`.

## Installation

The package is available at NuGet:

    dotnet add package CookiesTxtParser

## Usage

Parse a file into `CookieCollection`:

    CookiesTxt.Parser.ParseFileAsCookieCollection("/path/to/cookies.txt");

Parse a stream into `CookieCollection`:

    CookiesTxt.Parser.ParseStreamAsCookieCollection(stream);