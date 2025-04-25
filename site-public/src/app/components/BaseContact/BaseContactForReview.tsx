import BaseContact from './BaseContact';
import type { BranchForm } from '@sections/ReviewsSection/ReviewSchema';
import { BaseContactProps } from './BaseContact'; // asegúrate de exportar esa interfaz

const BaseContactForReview = (props: BaseContactProps<BranchForm>) => (
    <BaseContact {...props} />
);

export default BaseContactForReview;
