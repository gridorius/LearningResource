Vue.component('v-sec', {
    template: `
        <div>
            <parallax :src='src'></parallax>
            <section>
                <h1>{{name}}</h1>
                <h2>{{description}}</h2>
            </section>
        </div>
    `,
    props: ['src1', 'src2', 'name','description'],

});

Vue.component('parallax', {
    template: `
        <div>
            <div ref='img' style="height:500px;overflow:hidden">
                <img  :src='src' :style="{transform:'translateY('+(y/3-100)+'px)'}"></img>
            </div>
            <slot></slot>
        </div>
    `,
    props: ['src'],
    data() {
        return {
            y: 0,
        };
    },
    created() {
        window.addEventListener('scroll', (e) => {
            this.y = -this.$refs.img.getBoundingClientRect().y;
        });
    }

});

Vue.component('double-parallax', {
    template: `
        <div>
            <div class='parallax' ref='img' style="height:60vh;overflow:hidden">
                <img  :src='src2' :style="{transform:'translateY('+(y/2-100)+'px)'}"></img>
                <img  :src='src1' :style="{transform:'translateY('+(y/3)+'px)'}"></img>
            </div>
            <slot></slot>
        </div>
    `,
    props: ['src1','src2'],
    data() {
        return {
            y: 0,
        };
    },
    created() {
        window.addEventListener('scroll', (e) => {
            this.y = -this.$refs.img.getBoundingClientRect().y;
        });
    }

});

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

fetch('Home/BriefDescription').then(r => r.text()).then(t => JSON.parse(t.replace(/&quot;/g, '\"')).art).then(console.log);
