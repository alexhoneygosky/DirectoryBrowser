'use strict';

/**
 * @ngdoc function
 * @name appApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the appApp
 */
var directoryControllers = angular.module('appApp');

directoryControllers.controller('MainCtrl', ['$scope', 'File', '$q', 'usSpinnerService',
  function ($scope, File, $q, usSpinnerService) {


    $scope.Search = function(){
      usSpinnerService.spin('spinner-1');

      File.query({keywords: $scope.keywords}).$promise.then(function(result){
        $scope.files = result;
        $('#Searching_Modal').spin(false);
        $('#Searching_Modal').modal('hide')
      });

      usSpinnerService.stop('spinner-1');
    }


    $scope.startSpin = function(){
          usSpinnerService.spin('spinner-1');
      }
    $scope.stopSpin = function(){
          usSpinnerService.stop('spinner-1');
      }
}]);
