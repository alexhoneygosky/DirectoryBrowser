'use strict';

var browserServices = angular.module('browserServices', ['ngResource']);

browserServices.factory('File', ['$resource', function($resource) {
  var File = $resource("http://localhost:59565/", {}, {
    query: {method:'GET', params:{}, isArray:true}
  });

  return File;
}]);
