import { Review } from "@api/types/api-web-stack-base";

export const mockReviews: Review[] = [
  {
    id: 1,
    name: 'John Doe',
    comment: 'Great experience!',
    rate: 5,
    created: '2023-01-01T00:00:00Z',
    showInWeb: true
  },
  {
    id: 2,
    name: 'Jane Smith',
    comment: 'Very good service',
    rate: 4,
    created: '2023-01-02T00:00:00Z',
    showInWeb: true
  },
  {
    id: 3,
    name: 'Hidden Review',
    comment: 'Should not appear',
    rate: 3,
    created: '2023-01-03T00:00:00Z',
    showInWeb: false
  },
  {
    id: 4,
    name: 'No Comment',
    comment: null,
    rate: 5,
    created: '2023-01-04T00:00:00Z',
    showInWeb: true
  }
];

export const visibleMockReviews = mockReviews.filter(review => review.showInWeb && review.comment);