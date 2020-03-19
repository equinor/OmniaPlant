# Omnia Timeseries API changelog

All notable changes to this API will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/)

## [Unreleased]

## [Released]

## [v1.6]
### Added
- Response encoded in Protobuf added as an option.
- Added "Facility" as a mandatory new field that will represent the plant code the timeseries belongs to. Only valid facility codes according to Equinor Common Library (master data) will be accepted.
- Enhanced access control where we are able to control the access on source (e.g. Historian) across plants and on both source and plant (e.g. Historian from Åsgard B). This works both for both OAuth 2.0 grant flows (service-to-service and user impersonation).

### Removed
- Metadata removed from the data point response, you will only get the timeseries id and VQT (value, quality, timestamp).

### Changed
- You are not allowed to create a timeseries with the same name on the same facility, in version 1.5 the constraint was on the fields name + assetId.
- Creating a new timeseries object in v1.6 with facility = "XXX" where a timeseries already exists with the same name and assetId = "XXX" will be denied.
- The "facility" field is now mandatory as opposed to "assetId" in v1.5 that was optional. 

### Fixed
- Various backend tuning to improve the performance.

## [v1.5]
### Added
- Added support for retrieves datapoints from multiple timeseries (max 100) in one request.
- Added a new field "metadata" that can be used to add custom metadata on a timeseries (key,value pairs).
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
