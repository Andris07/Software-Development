<script setup>
import Box from '@components/Box.vue';
import Bubble from '@components/Bubble.vue';
import BaseLayout from '@layouts/BaseLayout.vue';
import { Bold } from '@lucide/vue';
import { formatDuration, ucfirst } from '@utils/helper';
import { api } from '@utils/http.mjs';
import { onMounted, ref, watch } from 'vue';
import { useRoute } from 'vue-router';

const course = ref({});
const loading = ref(true);

const route = useRoute();

async function loadCourse()
{
  const id = route.params.id;
  const response = await api.get(`api/courses/${id}`);
  course.value = response.data.data;
  loading.value = false;
}

onMounted(() =>
{
  loadCourse();
});

watch(route, () =>
{
  loadCourse();
});
</script>

<template>
  <BaseLayout>
    <div v-if="!loading" class="py-6">
      <RouterLink :to="{name: 'index'}" class="mb-8 inline-flex items-center gap-2 text-sm font-medium text-gray-500 hover:text-gray-900">
        <span aria-hidden="true">&larr;</span>
        Back to courses
      </RouterLink>

      <div class="grid md:grid-cols-2 gap-8">

        <!-- Left column -->
        <div>
          <img
            :src="course.image"
            :alt="course.image"
            class="aspect-video w-full rounded-2xl object-cover shadow-sm"
          />

          <!-- Enrollment + Price -->
          <div class="mt-8 flex justify-between items-center gap-8">
            <Box type="info">
              Enrollment coming soon
            </Box>

            <div class="flex flex-col shrink-0">
              <span class="mb-1 text-sm text-gray-500">
                Course price
              </span>

              <span class="text-4xl font-bold text-gray-900">
                ${{ Number(course.price).toFixed(2) }}
              </span>
            </div>
          </div>
        </div>

        <!-- Right column -->
        <div class="pt-6">

          <!-- Title + Level -->
          <h1 class="mb-4 text-3xl font-bold tracking-tight flex items-center justify-between gap-4 text-gray-900 md:text-4xl">
            {{ course.name }}
            <span>
              <Bubble>{{ ucfirst(course.level) }}</Bubble>
            </span>
          </h1>

          <!-- Author -->
          <div class="mb-8 flex items-center gap-2 text-gray-500">
            <span>Created by</span>

            <span class="font-medium text-gray-900">
              {{ course.author }}
            </span>
          </div>

          <!-- Lessons table -->
          <div class="overflow-hidden rounded-xl border border-gray-200 bg-white shadow-sm">
            <table class="w-full text-left text-sm">
              <thead class="bg-gray-50 text-xs uppercase tracking-wide text-gray-500">
                <tr>
                  <th scope="col" class="px-6 py-4 font-semibold">
                    Title
                  </th>

                  <th scope="col" class="px-6 py-4 text-right font-semibold">
                    Duration
                  </th>
                </tr>
              </thead>

              <tbody class="divide-y divide-gray-100">
                <tr
                  v-for="lesson in course.lessons"
                  :key="lesson.id"
                  class="transition-colors hover:bg-gray-50"
                >
                  <td class="px-4 py-4 font-medium text-gray-900">
                    <div class="flex items-center gap-4">
                      {{ lesson.title }}
                    </div>
                  </td>

                  <td class="whitespace-nowrap px-4 py-4 text-right tabular-nums text-gray-500">
                    {{ formatDuration(lesson.duration) }}
                  </td>
                </tr>
              </tbody>
            </table>
          </div>

        </div>
      </div>
    </div>
  </BaseLayout>
</template>

<style scoped>

</style>

<route lang="yaml">
name: courses.show
meta:
  title: Kurzus
</route>