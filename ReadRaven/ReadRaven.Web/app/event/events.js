(function () {
    'use strict';
    var controllerId = 'events';
    angular.module('app').controller(controllerId, ['common', 'datacontext', events]);

    function events(common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;

        vm.activate = activate;
        vm.eventCount = 0;
        vm.title = 'Analytics events';

        activate();

        function activate() {
            var promises = [getEventCount()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Events View'); });
        }

        function getEventCount() {
            return datacontext.getEventCount().then(function(data) {
                return vm.eventCount = data;
            });
        }
    }
})();
