var app = angular.module("myApp", []);

app.factory("mainFactory", function ($http) {
    var factory = {};

    factory.doPost = function (data, url) {
        return $http({
            url: url,
            method: "POST",
            headers: { 'Content-Type': 'application/json' },
            data: data
        }).then(function (response) {
            return response.data;
        });
    };

    factory.doGet = function (data, url) {
        return $http({
            url: url,
            method: "GET",
            headers: { 'Content-Type': 'application/json' },
            data: jQuery.param(data)
        }).then(function (response) {
            return response.data;
        });
    };

    return factory;
});