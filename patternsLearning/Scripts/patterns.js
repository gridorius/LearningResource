Vue.component('category', {
    template: `    
    <div>
            <h2 @click='selected = !selected;$root.showInfo = false' :title='description'>{{name}}</h2>
            <ul :class='{open:selected}'>
                <li v-for='art in article'><div :title='art.art_description'>{{art.art_name}}</div></li>
            </ul>
        </div>
    `,
    props: ['name', 'description','article'],
    data() {
        return {
            selected: false,
        }
    },
});

let app = new Vue({
    el: '.main',
    data: {
        showInfo: true,
        categories: [],
        info:''
    },
    methods: {
        setCategories(obj) {
            this.info = obj.section.sec_description;
            let categories = obj.section.category;
            this.categories.push(...categories.splice(0, 3));
        }
    }
});

fetch('/Patterns/PatternPageStructure').then(r => r.text()).then(t => JSON.parse(t.replace(/&quot;/g, '\"'))).then(app.setCategories);