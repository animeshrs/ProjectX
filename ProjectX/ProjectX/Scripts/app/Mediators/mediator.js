define(function (require) {
    var mediator = {};

    mediator.channels = require('channels');
    mediator.priorities = {
        "low": "low",
        "normal": "normal",
        "high": "high"
    };
    mediator.subscribe = function (channel, fn, priority) {
        /// <summary>
        /// foo
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="fn"></param>
        /// <param name="priority"></param>
        if (!channel) {
            console.debug("Subscription Channel not specified");
        }
        if (!fn) {
            throw "Callback not specified. channel: " + channel;
        }
        priority = priority || mediator.priorities.normal;

        //console.debug(new Date().toJSON() + ", Mediator.subscribe: " + channel);
        if (!mediator.channels[channel]) mediator.channels[channel] = { low: [], normal: [], high: [] };
        mediator.channels[channel][priority].push({ context: this, callback: fn });
    };
    mediator.publish = function (channel) {
        if (!channel) {
            console.debug("Publication Channel not specified");
        }
        console.debug(new Date().toJSON() + ", Mediator.publish: " + channel);
        if (!mediator.channels[channel]) {
            return false;
        }
        var args = Array.prototype.slice.call(arguments, 1);
        var subscription;
        var i, l;
        for (i = 0, l = mediator.channels[channel][mediator.priorities.high].length; i < l; i++) {
            subscription = mediator.channels[channel][mediator.priorities.high][i];
            subscription.callback.apply(subscription.context, args);
        }
        for (i = 0, l = mediator.channels[channel][mediator.priorities.normal].length; i < l; i++) {
            subscription = mediator.channels[channel][mediator.priorities.normal][i];
            subscription.callback.apply(subscription.context, args);
        }
        for (i = 0, l = mediator.channels[channel][mediator.priorities.low].length; i < l; i++) {
            subscription = mediator.channels[channel][mediator.priorities.low][i];
            subscription.callback.apply(subscription.context, args);
        }

        return true;
    };

    return mediator;

});