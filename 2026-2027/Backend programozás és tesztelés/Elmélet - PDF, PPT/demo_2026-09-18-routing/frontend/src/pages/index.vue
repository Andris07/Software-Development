<script setup>
import BaseLayout from '@layouts/BaseLayout.vue'
import { ref } from 'vue';


const count = ref(7);

count.value++;

function increment(n) {
    count.value += n;
}


const cars = ref([
    {
        "id": 1,
        "manufacturer": "Audi",
        "model": "A6",
        "color": "szürke",
        "consumption": 10.2,
        "background": "gray",
        "image": "audi-min.jpg",
        "url": "http://backend.localhost/api/cars/1"
    },
    {
        "id": 2,
        "manufacturer": "Suzuki",
        "model": "Swift",
        "color": "piros",
        "consumption": 6.9,
        "background": "red",
        "image": "swift-min.jpg",
        "url": "/api/cars/2"
    },
    {
        "id": 3,
        "manufacturer": "Suzuki",
        "model": "Ignis",
        "color": "sárga",
        "consumption": 7.3,
        "background": "yellow",
        "image": "ignis-min.jpg",
        "url": "/api/cars/3"
    }
]);


const manufacturer = ref("");
const model = ref("");

function addCar() {
    const car = {
        manufacturer: manufacturer.value,
        model: model.value,
        consumption: 8
    }
    cars.value.push(car)
    cars.value = cars.value.toSorted((a, b) => a.consumption - b.consumption)
}

</script>

<template>
    <BaseLayout>

        <main class="mx-auto max-w-7xl px-4">
            <div class="grid grid-cols-1 gap-6 md:grid-cols-3">


                <div v-for="car in cars"
                    @click="manufacturer = car.manufacturer ; model = car.model"
                    class="rounded-xl bg-white  transition:4s p-4 last:mb-4 shadow-lg hover:bg-blue-200 transition delay-150 duration-300"
                    >
                    <!-- <img class="w-full rounded-md border border-blue-200 bg-white p-1" :src="`/img/${car.image}`" :alt="car.manufacturer + ' ' + car.model"> -->

                    <h2 class="mt-3 text-base font-semibold">
                        #{{ car.id }} {{ car.manufacturer }} {{ car.model }}
                    </h2>

                    <p class="mt-1 text-sm text-gray-700">
                        Fogyasztás: {{ car.consumption }} liter/100km
                    </p>

                    <p class="mt-1 text-sm" :style="{ backgroundColor: car.background }">
                        Szín: {{ car.color }}
                    </p>
                </div>
            </div>

            <form @submit.prevent="addCar()" method="get" class="my-2 grid md:grid-cols-3 gap-4 items-end">
                <div>
                    <label for="manufacturer" class="block text-sm font-medium text-gray-700 mb-1">
                        Gyártó
                    </label>
                    <input v-model="manufacturer" type="text" name="manufacturer" id="manufacturer" class="w-full rounded-lg border border-slate-700 px-4 py-2 
               focus:ring-2 focus:ring-blue-300 focus:outline-none">
                </div>

                <div>
                    <label for="model" class="block text-sm font-medium text-gray-700 mb-1">
                        Típus
                    </label>
                    <input v-model="model" type="text" name="model" id="model" value="" class="w-full rounded-lg border border-slate-700 px-4 py-2 
               focus:ring-2 focus:ring-blue-300 focus:outline-none">
                </div>

                <input type="submit" value="Mentés" class="w-full bg-slate-600 hover:bg-slate-700 text-white 
               font-bold py-2 rounded-lg transition">
            </form>


            <div
                class="rounded-xl bg-white transition:4s p-4 last:mb-4 shadow-lg hover:bg-blue-200 transition delay-150 duration-300">
                <!-- <img class="w-full rounded-md border border-blue-200 bg-white p-1" :src="`/img/${car.image}`" :alt="car.manufacturer + ' ' + car.model"> -->
                <h2 class="mt-3 text-base font-semibold"> #1  {{ manufacturer }} 
            {{ model }}</h2>
                <p class="mt-1 text-sm text-gray-700"> Fogyasztás: 10.2 liter/100km </p>
                <p class="mt-1 text-sm" style="background-color: gray;"> Szín: szürke</p>
            </div>
           
        </main>

    </BaseLayout>
</template>

<route lang="yaml">
name: index
meta:
  title: Főoldal
</route>
