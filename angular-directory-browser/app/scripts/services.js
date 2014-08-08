'use strict';

var browserServices = angular.module('browserServices', ['ngResource']);

browserServices.factory('File', ['$resource', function($resource) {
  var File = $resource("192.168.68.175/DBService/", {}, {
    query: {method:'GET', params:{}, isArray:true}
  });

  return File;
}]);
