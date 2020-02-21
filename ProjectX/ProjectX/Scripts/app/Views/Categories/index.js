define(function (require) {
    require('jquery');

    let alert = () => {
        console.log('index js loaded');
    };

    let initialize = () => {
        alert();
    };

    return {
        initialize: initialize
    };
})