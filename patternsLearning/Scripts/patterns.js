Vue.component('category', {
    template: `    
    <div>
            <h2 @click='selected = !selected'>{{Name}}</h2>
            <ul :class='{open:selected}'>
                <li v-for='pattern in patterns'>{{pattern.Name}}</li>
            </ul>
        </div>
    `,
    props: ['Name', 'patterns'],
    data() {
        return {
            selected: false,
        }
    },
});

let app = new Vue({
    el: '.main',
    data: {
        show: false,
        categories: [
            {
                Name: 'Порождающие',
                patterns: [
                    { Name: 'Фабричный метод' },
                    { Name: 'Абстрактная фабрика' },
                    { Name: 'Строитель' }
                ]
            },
            {
                Name: 'Структурные',
                patterns: [
                    { Name: 'Адаптер' },
                    { Name: 'Мост' },
                    { Name: 'Компоновщик' }
                ]
            }, {
                Name: 'Поведенческие',
                patterns: [
                    { Name: 'Цепочка обязаностей' },
                    { Name: 'Команда' },
                    { Name: 'Итератор' }
                ]
            }
        ],
    },
});