function readCookie(name) {
    var nameEq = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEq) === 0) return c.substring(nameEq.length, c.length);
    }
    return null;
}

require.config({
    baseUrl: '/Scripts',
    waitSeconds: 0,
    paths: {
        'views': 'app/Views',

        //Mediators
        'mediator': 'app/Mediators/mediator',
        'channels': 'app/Mediators/channels',

        //Services
        'services': 'app/Modules/Services',

        // jQuery
        'jquery': ['https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.js', 'jquery-3.4.1'],
        'jquery-migrate': ['https://cdnjs.cloudflare.com/ajax/libs/jquery-migrate/3.1.0/jquery-migrate.js'],
        'jquery-validate': ['https://ajax.aspnetcdn.com/ajax/jquery.validate/1.17.0/jquery.validate.js', 'jquery.validate'],
        'jquery.validate.unobtrusive': 'jquery.validate.unobtrusive'
    },
    priority: ['jquery'],
    shim: {
        'jquery.validate': ['jquery'],
        'jquery.validate.unobtrusive': ['jquery', 'jquery.validate']
    },
    urlArgs: "v=" + readCookie('cache-buster-tag')
});