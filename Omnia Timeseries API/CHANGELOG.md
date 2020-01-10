# Omnia Timeseries API changelog

All notable changes to this API will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/)

## [Unreleased]

## [v1.5]
### Added
- Added support for retrieves datapoints from multiple timeseries (max 100) in one request.
- Both afterTime and beforeTime (bounds) now optional parameters when getting the first datapoint.
- Both afterTime and beforeTime (bounds) now optional parameters when getting the last datapoint.
- Added support for filtering on datapoint status on both raw and aggregated timeseries data.
- The return limit for data points is now increased to 100 000.

## [v1.4]
### Added
- Added support to authenticate on behalf of a user and authorize based on AD group membership. Only for users with Equinor accounts.
- New endpoint for deleting timeseries data points and timeseries metadata objects

## [v1.3]
### Added
- Writing timeseries data points using HTTP POST on one or multiple timeseries, with the option of choosing it to be asynchronous or not.
- Wildcard (using asterisk) search on the timeseries metadata fields name, description and unit, and now support for starting the search with asterisk
- Filtering on multiple fields in timeseries list

## [v1.2]
### Added
- Get aggregated timeseries data (avg, min, max, sum, stddev, count) according to time window, processing interval and filling of empty processing intervals.
- Wildcard (using asterisk) search on timeseries name (currently not supporting searches starting with asterisk)

## [v1.1]
### Added
- Create one timeseries metadata object
- Partial update of one timeseries metadata object
- Full update of one timeseries metadata object
- Retrieve one timeseries metadata object by id
- Retrieve a list of all timeseries, or a subset based on one of the query parameters: name, externalId or assetId
- Retrieve raw data points (timeseries data) within a given time window (id, startTime, endTime)
- Include outside data points (left and right outside points)
- Retrieve first data point of a timeseries
- Retrieve latest data point of a timeseries
- Support for paging (by continuation token) on both timeseries metadata and timeseries data
