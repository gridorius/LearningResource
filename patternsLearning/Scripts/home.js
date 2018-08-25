
let app = new Vue({
    el: '.main',
    data: {
        briefDescriptions: [],
    },
    methods: {
        setBriefDescription(arr) {
            this.briefDescriptions = arr;
        }
    }
});

fetch('/Home/BriefDescription').then(r => r.text()).then(t => JSON.parse(t.replace(/&quot;/g, '\"')).art).then(app.setBriefDescription);
